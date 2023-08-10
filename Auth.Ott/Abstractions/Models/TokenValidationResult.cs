﻿using System.Security.Claims;

namespace Auth.Ott.Abstractions.Models
{
    /// <summary>
    /// An one time access token validation result.
    /// </summary>
    /// <autogeneratedoc />
    public class TokenValidationResult
    {
        /// <summary>
        /// <c>true</c>, if the token is valid; otherwise <c>false</c>.
        /// </summary>
        public bool IsValid { get; private set; }

        /// <summary>
        /// Claims added to authentication result.
        /// </summary>
        public IEnumerable<Claim> Claims { get; private set; }

        /// <summary>
        /// Indicates an authorized access.
        /// </summary>
        public static TokenValidationResult Success(IEnumerable<Claim> claims)
            => new TokenValidationResult()
            {
                IsValid = true,
                Claims = claims?
                    .Where(claim => claim != null).ToArray()
                    ?? Array.Empty<Claim>()
            };

        /// <summary>
        /// Indicates an unauthorized access.
        /// </summary>
        public static TokenValidationResult Failed()
            => new TokenValidationResult() { IsValid = false };
    }
}