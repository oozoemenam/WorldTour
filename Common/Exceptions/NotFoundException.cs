﻿namespace WorldTour.Common.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) {}
    
    public NotFoundException(string message, Exception innerException) : base(message, innerException) {}
    
    public NotFoundException(string name, object key) : base($"Entity \"{name}\" ({key}) not found.") {}
}