﻿using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;
using Minotaur.CommonParts.Types;

namespace Minotaur.Identity.Domain
{
    public class User : IIdentifiable
    {
        private static readonly Regex EmailRegex = new Regex(
            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);
            
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string Login { get; private set; }
        public string Role { get; private set; }
        public string PasswordHash { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        protected User(string login)
        {
            Login = login;
        }

        public User(Guid id, string email, string role, string login)
        {
            if (!EmailRegex.IsMatch(email))
            {
                throw new MinotaurException(Codes.InvalidEmail, 
                    $"Invalid email: '{email}'.");
            }
            if (!Domain.Role.IsValid(role))
            {
                throw new MinotaurException(Codes.InvalidRole, 
                    $"Invalid role: '{role}'.");
            }        
            Id = id;
            Login = login.ToLowerInvariant();
            Email = email.ToLowerInvariant();
            Role = role.ToLowerInvariant();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password, IPasswordHasher<User> passwordHasher)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new MinotaurException(Codes.InvalidPassword, 
                    "Password can not be empty.");
            }             
            PasswordHash = passwordHasher.HashPassword(this, password);
        }

        public bool ValidatePassword(string password, IPasswordHasher<User> passwordHasher)
            => passwordHasher.VerifyHashedPassword(this, PasswordHash, password) != PasswordVerificationResult.Failed;
    }
}