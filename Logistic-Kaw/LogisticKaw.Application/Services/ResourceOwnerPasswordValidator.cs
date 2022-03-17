using IdentityServer4.Models;
using IdentityServer4.Validation;
using LogisticKaw.Application.Helpers;
using LogisticKaw.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LogisticKaw.Application.Services
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public ResourceOwnerPasswordValidator(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = _unitOfWork.Users.Find(context.UserName);

            if (context.UserName.Equals(user) && 
                context.Password.Equals(CryptorHelper.DecryptPassword(user.Password, _configuration["Settings:CryptoKey"])))
            {
                var customClaims = new[]
                {
                    new Claim("custom_claim", "custom_value"),
                };
                context.Result = new GrantValidationResult(context.UserName, GrantType.ResourceOwnerPassword, customClaims);
            }

            return Task.CompletedTask;
        }
    }
}
