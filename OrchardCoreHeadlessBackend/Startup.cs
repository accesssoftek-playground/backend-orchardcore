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
            .GetSection("OrchardCore:OrchardCoreHeadlessBackend:EnabledModules")
            .Get<string>();
        
        services
            .AddOrchardCms()
            .AddSetupFeatures("OrchardCore.AutoSetup")
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