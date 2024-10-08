using WorldTour.Dtos;
using WorldTour.Models;

namespace WorldTour.Common.Interfaces;

public interface IUserService
{
    AuthenticateResponse? Authenticate(AuthenticateRequest model);
    User? GetById(int id); 
}