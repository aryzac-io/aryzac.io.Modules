using Intent.Engine;
using Intent.Metadata.Models;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiMetadataDesignerExtensions", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Api
{
    public static class ApiMetadataDesignerExtensions
    {
        public static IDesigner Client(this IMetadataManager metadataManager, IApplication application)
        {
            return metadataManager.Client(application.Id);
        }

        public static IDesigner Client(this IMetadataManager metadataManager, string applicationId)
        {
            return metadataManager.GetDesigner(applicationId, "Client");
        }

    }
}