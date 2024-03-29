﻿using System;
using System.Threading.Tasks;
using Minotaur.CommonParts.Authentication;

namespace Minotaur.Identity.Services
{
    public interface IRefreshTokenService
    {
        Task AddAsync(Guid userId);
        Task<JsonWebToken> CreateAccessTokenAsync(string refreshToken);
        Task RevokeAsync(string refreshToken, Guid userId);
    }
}