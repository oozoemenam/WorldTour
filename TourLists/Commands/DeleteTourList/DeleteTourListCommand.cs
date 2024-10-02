using MediatR;
using Microsoft.EntityFrameworkCore;
using WorldTour.Common.Exceptions;
using WorldTour.Common.Interfaces;
using WorldTour.Models;

namespace WorldTour.TourLists.Commands.DeleteTourList;

public class DeleteTourListCommand : IRequest
{
    public int Id { get; set; }
}

public class DeleteTourListCommandHandler : IRequestHandler<DeleteTourListCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteTourListCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteTourListCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TourLists
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);
        if (entity == null)
        {
            throw new NotFoundException(nameof(TourList), request.Id);
        }

        _context.TourLists.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        // return Unit.Value;
    }
}