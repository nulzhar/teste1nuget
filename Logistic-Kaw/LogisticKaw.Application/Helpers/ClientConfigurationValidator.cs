using IdentityServer4.Validation;
using System;
using System.Threading.Tasks;

namespace LogisticKaw.Application.Helpers
{
    public class ClientConfigurationValidator : IClientConfigurationValidator
    {
        public Task ValidateAsync(ClientConfigurationValidationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
