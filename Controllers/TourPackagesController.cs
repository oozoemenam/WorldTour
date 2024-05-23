using Microsoft.AspNetCore.Mvc;
using WorldTour.Data.Models;
using WorldTour.Data;

namespace WorldTour.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourPackagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TourPackagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.TourPackages);   
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TourPackage tourPackage)
        {
            await _context.TourPackages.AddAsync(tourPackage);  
            await _context.SaveChangesAsync();
            return Ok(tourPackage);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TourPackage tourPackage)
        {
            _context.Update(tourPackage);
            await _context.SaveChangesAsync();
            return Ok(tourPackage);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            // TODO:
            var tourPackage = await _context.TourPackages.FindAsync(id);
            if (tourPackage == null) return NotFound();
            _context.TourPackages.Remove(tourPackage);
            await _context.SaveChangesAsync(true);
            return Ok(tourPackage);
        }
    }
}
