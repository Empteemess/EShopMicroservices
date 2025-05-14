using FluentValidation.AspNetCore;

namespace Catalog.Api.Configurations;

public static class ValidatorConfigurations
{
    public static IServiceCollection AddValidatorConfigurations(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        
        return services;
    }
}