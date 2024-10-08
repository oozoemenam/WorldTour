﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorldTour.Common.Helpers;

namespace WorldTour.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public abstract class ApiController: ControllerBase
{
    private IMediator? _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;
}