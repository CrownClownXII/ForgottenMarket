using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CatalogAPI.DAL.Data;
using CatalogAPI.DAL.Model;
using CatalogAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CatalogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly ILogger<CatalogController> _logger;
        private readonly CatalogContext _context; 
        private readonly IMapper _mapper;

        public CatalogController(ILogger<CatalogController> logger, CatalogContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("test")]
        public ActionResult Test()
        {
            return Ok("Ok");
        }

        [HttpGet("list")]
        public async Task<ActionResult> Get([FromQuery]CatalogItemFilters filters)
        {
            var list = await _context.CatalogItems
                .Skip(filters.PageSize * filters.PageNumber)
                .Take(filters.PageSize)
                .ToListAsync();

            var totalItemNumber = _context.CatalogItems.Count();

            var result = new CatalogItemListDto
            {
                TotalItemNumber = totalItemNumber,
                TotalPages = (totalItemNumber/filters.PageSize) + (totalItemNumber%filters.PageSize > 0 ? 1 : 0),
                List = _mapper.Map<List<CatalogItem>, List<CatalogItemDto>>(list),
                ItemsOnPageNumber = list.Count,
                PageSize = filters.PageSize,
                PageNumber = filters.PageNumber
            };

            return Ok(result);
        }
        
        [HttpPost("add")]
        public async Task<ActionResult> Post([FromForm]CreateCatalogItemDto item)
        {
            var itemInDb = _mapper.Map<CreateCatalogItemDto, CatalogItem>(item);

            var extension = Path.GetExtension(item.Image.FileName);

            itemInDb.MainImageName = $"{Guid.NewGuid().ToString()}.{extension}";

            var imgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", itemInDb.MainImageName);

            using(var stream = new FileStream(imgPath, FileMode.Create))
            {
                await item.Image.CopyToAsync(stream);
            }

            await _context.CatalogItems.AddAsync(itemInDb);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<CatalogItem, CreateCatalogItemDto>(itemInDb);

            return Ok(result);
        }
    }
}
