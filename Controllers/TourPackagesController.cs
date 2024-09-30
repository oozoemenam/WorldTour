using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorldTour.Data;
using WorldTour.Models;

namespace WorldTour.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TourPackagesController : ControllerBase
{
    private readonly TourDbContext _context;

    public TourPackagesController(TourDbContext context)
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var tourPackage = await _context.TourPackages.SingleOrDefaultAsync(i => i.Id == id);
        if (tourPackage == null) return NotFound();
        _context.TourPackages.Remove(tourPackage);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TourPackage tourPackage)
    {
        _context.Update(tourPackage);
        await _context.SaveChangesAsync();
        return Ok(tourPackage);
    }
}