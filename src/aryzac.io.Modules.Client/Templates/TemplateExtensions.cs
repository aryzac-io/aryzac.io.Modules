using System.Collections.Generic;
using Aryzac.IO.Modules.Client.Templates.Files.Composables.UseServiceProxy;
using Aryzac.IO.Modules.Client.Templates.Files.NuxtConfig;
using Aryzac.IO.Modules.Client.Templates.Files.Services.ServiceProxy;
using Aryzac.IO.Modules.Client.Templates.Files.Structs.DTOs.DTO;
using Aryzac.IO.Modules.Client.Templates.Files.Structs.DTOs.JsonResponse;
using Intent.Modelers.Services.Api;
using Intent.Modelers.Types.ServiceProxies.Api;
using Intent.Modules.Common.Templates;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: DefaultIntentManaged(Mode.Fully, Targets = Targets.Usings)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.TemplateExtensions", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Templates
{
    public static class TemplateExtensions
    {
        public static string GetUseServiceProxyName<T>(this IIntentTemplate<T> template) where T : ServiceProxyModel
        {
            return template.GetTypeName(UseServiceProxyTemplate.TemplateId, template.Model);
        }

        public static string GetUseServiceProxyName(this IIntentTemplate template, ServiceProxyModel model)
        {
            return template.GetTypeName(UseServiceProxyTemplate.TemplateId, model);
        }

        public static string GetNuxtConfigName(this IIntentTemplate template)
        {
            return template.GetTypeName(NuxtConfigTemplate.TemplateId);
        }
        public static string GetServiceProxyName<T>(this IIntentTemplate<T> template) where T : ServiceProxyModel
        {
            return template.GetTypeName(ServiceProxyTemplate.TemplateId, template.Model);
        }

        public static string GetServiceProxyName(this IIntentTemplate template, ServiceProxyModel model)
        {
            return template.GetTypeName(ServiceProxyTemplate.TemplateId, model);
        }
        public static string GetDTOName<T>(this IIntentTemplate<T> template) where T : DTOModel
        {
            return template.GetTypeName(DTOTemplate.TemplateId, template.Model);
        }

        public static string GetDTOName(this IIntentTemplate template, DTOModel model)
        {
            return template.GetTypeName(DTOTemplate.TemplateId, model);
        }

        public static string GetJsonResponseName(this IIntentTemplate template)
        {
            return template.GetTypeName(JsonResponseTemplate.TemplateId);
        }

    }
}