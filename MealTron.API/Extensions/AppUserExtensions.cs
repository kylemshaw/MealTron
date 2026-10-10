using System;
using MealTron.API.DTOs;
using MealTron.API.Entities;
using MealTron.API.Interfaces;

namespace MealTron.API.Extensions;

public static class AppUserExtensions
{
    public static UserDto ToDto(this AppUser user, ITokenService tokenService)
    {
        return new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            DisplayName = user.DisplayName,
            Token = tokenService.CreateToken(user)
        };
    }

}
