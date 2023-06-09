﻿using Microsoft.AspNetCore.Identity;
using Shared.DTOs;

namespace Service.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserCreationDto userCreationDto);
        Task<bool> ValidateUser(UserAuthenticationDto userAuth);
        Task<TokenDto> CreateToken(bool setExpiration);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
    }
}
