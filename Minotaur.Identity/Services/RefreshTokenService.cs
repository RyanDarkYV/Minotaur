using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Minotaur.CommonParts.Authentication;
using Minotaur.CommonParts.RabbitMq;
using Minotaur.CommonParts.Types;
using Minotaur.Identity.Domain;
using Minotaur.Identity.Messages.Events;
using Minotaur.Identity.Repositories;

namespace Minotaur.Identity.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IClaimsProvider _claimsProvider;
        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IBusPublisher _busPublisher;
        private readonly IJwtHandler _jwtHandler;

        public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository, IBusPublisher busPublisher, IJwtHandler jwtHandler, IUserRepository userRepository, IClaimsProvider claimsProvider, IPasswordHasher<User> passwordHasher)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _busPublisher = busPublisher;
            _jwtHandler = jwtHandler;
            _userRepository = userRepository;
            _claimsProvider = claimsProvider;
            _passwordHasher = passwordHasher;
        }

        public async Task AddAsync(Guid userId)
        {
            var user = await _userRepository.GetAsync(userId);
            if (user == null)
            {
                throw new MinotaurException(Codes.UserNotFound, $"User: {userId} was not found.");
                
            }

            await _refreshTokenRepository.AddAsync(new RefreshToken(user, _passwordHasher));
        }

        public Task<JsonWebToken> CreateAccessTokenAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public async Task RevokeAsync(string token, Guid userId)
        {
            var refreshToken = await _refreshTokenRepository.GetAsync(token);
            if (refreshToken == null || refreshToken.UserId != userId)
            {
                throw new MinotaurException(Codes.RefreshTokenNotFound, 
                    "Refresh token was not found.");
            }
            refreshToken.Revoke();
            await _refreshTokenRepository.UpdateAsync(refreshToken);
            await _busPublisher.PublishAsync(new RefreshTokenRevoked(refreshToken.UserId), CorrelationContext.Empty);
        }
    }
}