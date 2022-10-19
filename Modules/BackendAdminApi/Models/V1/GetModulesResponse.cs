namespace BackendAdminApi.Models.V1;

public sealed class GetModulesResponse
{
    public List<string>? AvailableModules { get; set; }
    public List<string>? EnabledModules { get; set; }
}