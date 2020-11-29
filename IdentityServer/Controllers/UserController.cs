using System;
using System.Threading.Tasks;
using AutoMapper;
using IdentityServer.DAL.Data;
using IdentityServer.DAL.Model;
using IdentityServer.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly IdentityContext _context;
        private readonly IMapper _mapper;

        public UserController(IdentityContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateUser([FromBody]UserDto userDto)
        {
            var user = _mapper.Map<UserDto, User>(userDto);

            try 
            {
                CreatePasswordHash(userDto.Password, user);

                _context.Users.Add(user);

                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }

            return Ok(_mapper.Map<User, UserDto>(user));
        }  

        private void CreatePasswordHash(string password, User user)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                user.PasswordSalt = hmac.Key;
                user.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}