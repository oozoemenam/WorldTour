using MediatR;
using WorldTour.Common.Exceptions;
using WorldTour.Common.Interfaces;
using WorldTour.Models;

namespace WorldTour.TourPackages.Commands.DeleteTourPackage;

public class DeleteTourPackageCommand : IRequest
{
    public int Id { get; set; }
}

public class DeleteTourPackageCommandHandler : IRequestHandler<DeleteTourPackageCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteTourPackageCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteTourPackageCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TourPackages.FindAsync(request.Id);
        if (entity == null)
        {
            throw new NotFoundException(nameof(TourPackage), request.Id);
        }

        _context.TourPackages.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        // return Unit.Value;
    }
}