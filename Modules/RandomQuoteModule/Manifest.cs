using Backend.Contracts.Orchard;
using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "Random Quote Feature",
    Author = "SIT Team",
    Website = "https://www.accesssoftek.com",
    Version = "0.1.0",
    Category = ModuleConstants.Category,
    Description = "Returns random quote",
    Tags = new[] {ModuleConstants.Tags.Optional}
)]