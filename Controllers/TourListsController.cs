using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorldTour.Data;
using WorldTour.Models;

namespace WorldTour.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TourListsController : ControllerBase
{
    private readonly TourDbContext _context;

    public TourListsController(TourDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.TourLists);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TourList tourList)
    {
        await _context.TourLists.AddAsync(tourList);
        await _context.SaveChangesAsync();
        return Ok(tourList);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var tourList = await _context.TourLists.SingleOrDefaultAsync(i => i.Id == id);
        if (tourList == null) return NotFound();
        _context.TourLists.Remove(tourList);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TourList tourList)
    {
        _context.Update(tourList);
        await _context.SaveChangesAsync();
        return Ok(tourList);
    }
}