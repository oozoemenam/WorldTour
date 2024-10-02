using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorldTour.Data;
using WorldTour.Models;
using WorldTour.TourPackages.Commands.CreateTourPackage;
using WorldTour.TourPackages.Commands.DeleteTourPackage;
using WorldTour.TourPackages.Commands.UpdateTourPackage;
using WorldTour.TourPackages.Commands.UpdateTourPackageDetail;

namespace WorldTour.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TourPackagesController : ApiController
{
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateTourPackageCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateTourPackageCommand command)
    {
        if (id != command.Id) return BadRequest();
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpPut("[action]")]
    public async Task<ActionResult> UpdateItemDetails([FromRoute] int id, [FromBody] UpdateTourPackageDetailCommand command)
    {
        if (id != command.Id) return BadRequest();
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        await Mediator.Send(new DeleteTourPackageCommand { Id = id });
        return NoContent();
    }
}