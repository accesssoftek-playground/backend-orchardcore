namespace OrchardCoreHeadlessBackend;

internal static class Constants
{
    internal static class Modules
    {
        public const string AutoSetup = "OrchardCore.AutoSetup";
        public static readonly string[] GlobalFeatures =
        {
            "SqlitePersistenceModule",
            "BackendAdminApi"
        };
    }

    internal static class Configuration
    {
        public const string EnabledModules = "OrchardCore:OrchardCoreHeadlessBackend:EnabledModules";
    }
}