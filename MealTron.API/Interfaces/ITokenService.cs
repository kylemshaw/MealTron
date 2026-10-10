using System;
using MealTron.API.Entities;

namespace MealTron.API.Interfaces;

public interface ITokenService
{
    string CreateToken(AppUser user);
    
}
