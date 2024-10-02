using System.Globalization;

namespace WorldTour.Common.Exceptions;

public class ApiException : Exception
{
    public ApiException(string message) : base(message) {}
    
    public ApiException(string message, params object[] args) : base(string.Format(CultureInfo.CurrentCulture, message, args)) {}
}