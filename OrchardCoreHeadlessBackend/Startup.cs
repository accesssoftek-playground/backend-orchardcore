namespace OrchardCoreHeadlessBackend;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var enabledModules = _configuration
            .GetSection(Constants.Configuration.EnabledModules)
            .Get<string>() ?? string.Empty;
        
        services
            .AddOrchardCms()
            .AddSetupFeatures(Constants.Modules.AutoSetup)
            .AddGlobalFeatures(Constants.Modules.GlobalFeatures)
            .AddTenantFeatures(enabledModules.Split(';'));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
        app.UseOrchardCore();
    }
}