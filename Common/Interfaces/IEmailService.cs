using WorldTour.Dtos;

namespace WorldTour.Common.Interfaces;

public interface IEmailService
{
    Task SendAsync(EmailDto request);
}