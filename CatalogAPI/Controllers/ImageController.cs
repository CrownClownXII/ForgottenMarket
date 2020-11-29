using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using CatalogAPI.DAL.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CatalogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly ILogger<ImageController> _logger;
        private readonly CatalogContext _context; 
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public ImageController(ILogger<ImageController> logger, CatalogContext context, IMapper mapper, IWebHostEnvironment env)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _env = env;
        }

        [HttpGet]
        public async Task<ActionResult> GetMainImageForCatalogItem(long catalogItemId)
        {
            if(catalogItemId <= 0)
            {
                return BadRequest();
            }

            var catalogItem = await _context.CatalogItems.FirstOrDefaultAsync(c => c.Id == catalogItemId);

            if(catalogItem != null) 
            {
                // var webRoot = _env.WebRootPath;
                // var path = Path.Combine(webRoot, catalogItem.MainImageName.ToString());
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", catalogItem.MainImageName);


                var buffer = await System.IO.File.ReadAllBytesAsync(path);

                return File(buffer, "image/png");
            }

            return NotFound();
        }
    }
}