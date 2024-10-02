using Microsoft.AspNetCore.Mvc;
using WorldTour.TourLists.Commands.CreateTourList;
using WorldTour.TourLists.Commands.DeleteTourList;
using WorldTour.TourLists.Commands.UpdateTourList;
using WorldTour.TourLists.GetTours;
using WorldTour.TourLists.Queries.ExportTours;
using WorldTour.TourLists.Queries.GetTours;

namespace WorldTour.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TourListsController : ApiController
{
    [HttpGet]
    public async Task<ActionResult<ToursVm>> Get()
    {
        return await Mediator.Send(new GetToursQuery());
    }

    [HttpGet("{id}")]
    public async Task<FileResult> Get(int id)
    {
        var vm = await Mediator.Send(new ExportToursQuery { ListId = id });
        return File(vm.Content, vm.ContentType, vm.FileName);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateTourListCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateTourListCommand command)
    {
        if (id != command.Id) return BadRequest();
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        await Mediator.Send(new DeleteTourListCommand { Id = id });
        return NoContent();
    }
}