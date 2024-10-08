﻿using MediatR;
using WorldTour.Common.Exceptions;
using WorldTour.Common.Interfaces;
using WorldTour.Models;

namespace WorldTour.TourPackages.Commands.UpdateTourPackage;

public class UpdateTourPackageCommand : IRequest
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

public class UpdateTourPackageCommandHandler : IRequestHandler<UpdateTourPackageCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateTourPackageCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateTourPackageCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TourPackages.FindAsync(request.Id);
        if (entity == null)
        {
            throw new NotFoundException(nameof(TourPackage), request.Id);
        }

        entity.Name = request.Name;
        await _context.SaveChangesAsync(cancellationToken);
        // return Unit.Value;
    }
}