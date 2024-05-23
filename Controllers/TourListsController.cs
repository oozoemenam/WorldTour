using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WorldTour.Data.Models;
using WorldTour.Data;

namespace WorldTour.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourListsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TourListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.TourList);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TourList tourList)
        {
            await _context.TourList.AddAsync(tourList);
            await _context.SaveChangesAsync();

            return Ok(tourList);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var tourList = await _context.TourList.SingleOrDefaultAsync(tl => tl.Id == id);

            if (tourList == null)
            {
                return NotFound();
            }

            _context.TourList.Remove(tourList);
            await _context.SaveChangesAsync();

            return Ok(tourList);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TourList tourList)
        {
            _context.Update(tourList);

            await _context.SaveChangesAsync();

            return Ok(tourList);
        }
    }
}