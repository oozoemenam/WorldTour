using System.ComponentModel.DataAnnotations;

namespace WorldTour.Dtos;

public class AuthenticateRequest
{
    [Required]
    public string? Username { get; set; }
    
    [Required]
    public string? Password { get; set; }
}