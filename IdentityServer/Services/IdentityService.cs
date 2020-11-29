using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer.DAL.Data;
using IdentityServer.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IdentityContext _context;

        public IdentityService(IdentityContext context)
        {
            _context = context;
        }

        public Task<User> FindByLogin(string login)
        {
            return _context.Users
                .FirstOrDefaultAsync(c => c.Login == login);
        }

        public Task<User> FindById(long userId)
        {
            return _context.Users
                .FirstOrDefaultAsync(c => c.Id == userId);
        }

        public string Authenticate(string password, byte[] hash, byte[] salt)
        {
            try
            {
                var result = VerifyPasswordHash(password, hash, salt);

                if(result){
                    return string.Empty;
                }
            }
            catch(ArgumentNullException e)
            {
                return e.Message;
            }

            return "Błędne hasło";
        }

        public async Task<List<Claim>> GetClaimsForUser(long userId)
        {
            var user = await FindById(userId);

            var claims = new List<Claim>()
            {
                new Claim("userId", userId.ToString()),
                new Claim("login", user.Login)
            };

            return claims;
        }

        private void ValidatePassword(string password, byte[] hash, byte[] salt) 
        {
            if (password == null) 
            {
                throw new ArgumentNullException("password");
            }
            if (string.IsNullOrWhiteSpace(password)) 
            {            
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            }
            if (hash.Length != 64)
            {
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            }
            if (salt.Length != 128) 
            {
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");
            }
        }

        private bool VerifyPasswordHash(string password, byte[] hash, byte[] salt)
        {
            ValidatePassword(password, hash, salt);

            using (var hmac = new System.Security.Cryptography.HMACSHA512(salt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != hash[i]) return false;
                }
            }

            return true;
        }  
    }
}