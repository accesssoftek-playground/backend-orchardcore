using Backend.Contracts.Orchard;
using BackendAdminApi.Models.V1;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.Environment.Extensions.Features;
using OrchardCore.Environment.Shell;

namespace BackendAdminApi.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[Route(Constants.RouteTemplate)]
public sealed class ModulesController : Controller
{
    private readonly IShellFeaturesManager _shellFeaturesManager;

    public ModulesController(IShellFeaturesManager shellFeaturesManager)
    {
        _shellFeaturesManager = shellFeaturesManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var avail = (await _shellFeaturesManager.GetAvailableFeaturesAsync()) ?? Enumerable.Empty<IFeatureInfo>();
        var enabled = (await _shellFeaturesManager.GetEnabledFeaturesAsync()) ?? Enumerable.Empty<IFeatureInfo>();
        
        List<string> Convert(IEnumerable<IFeatureInfo> source) => 
            source
                .Where(_ => _.Category == ModuleConstants.Category && (_.Extension?.Manifest?.Tags?.Contains(ModuleConstants.Tags.Optional) ?? false))
                .Select(_ => _.Id)
                .ToList();
        
        return Ok(new GetModulesResponse
        {
            AvailableModules = Convert(avail),
            EnabledModules = Convert(enabled),
        });
    }
}