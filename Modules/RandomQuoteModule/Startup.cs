using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;

namespace RandomQuoteModule;

public class Startup : StartupBase
{
    public override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = ApiVersion.Neutral;
            options.AssumeDefaultVersionWhenUnspecified = true;
        });
    }
}