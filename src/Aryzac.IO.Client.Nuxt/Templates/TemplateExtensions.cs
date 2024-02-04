using System.Collections.Generic;
using Aryzac.IO.Modules.Client.Api;
using Aryzac.IO.Client.Nuxt.Templates.Files.Composables.Controls.UseHeadingOptions;
using Aryzac.IO.Client.Nuxt.Templates.Files.Composables.Controls.UseLabelOptions;
using Aryzac.IO.Client.Nuxt.Templates.Files.Composables.Controls.UseSelectOptions;
using Aryzac.IO.Client.Nuxt.Templates.Files.Composables.Controls.UseTableOptions;
using Aryzac.IO.Client.Nuxt.Templates.Files.Composables.UseServiceProxy;
using Aryzac.IO.Client.Nuxt.Templates.Files.NuxtConfig;
using Aryzac.IO.Client.Nuxt.Templates.Files.Services.ServiceProxy;
using Aryzac.IO.Client.Nuxt.Templates.Files.Structs.Components.Models;
using Aryzac.IO.Client.Nuxt.Templates.Files.Structs.Components.Props;
using Aryzac.IO.Client.Nuxt.Templates.Files.Structs.DTOs.DTO;
using Aryzac.IO.Client.Nuxt.Templates.Files.Structs.DTOs.JsonResponse;
using Intent.Modelers.Services.Api;
using Intent.Modelers.Types.ServiceProxies.Api;
using Intent.Modules.Common.Templates;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: DefaultIntentManaged(Mode.Fully, Targets = Targets.Usings)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.TemplateExtensions", Version = "1.0")]

namespace Aryzac.IO.Client.Nuxt.Templates
{
    public static class TemplateExtensions
    {
        public static string GetUseHeadingOptionsName<T>(this IIntentTemplate<T> template) where T : HeadingModel
        {
            return template.GetTypeName(UseHeadingOptionsTemplate.TemplateId, template.Model);
        }

        public static string GetUseHeadingOptionsName(this IIntentTemplate template, HeadingModel model)
        {
            return template.GetTypeName(UseHeadingOptionsTemplate.TemplateId, model);
        }

        public static string GetUseLabelOptionsName<T>(this IIntentTemplate<T> template) where T : LabelModel
        {
            return template.GetTypeName(UseLabelOptionsTemplate.TemplateId, template.Model);
        }

        public static string GetUseLabelOptionsName(this IIntentTemplate template, LabelModel model)
        {
            return template.GetTypeName(UseLabelOptionsTemplate.TemplateId, model);
        }
        public static string GetUseSelectOptionsName<T>(this IIntentTemplate<T> template) where T : SelectModel
        {
            return template.GetTypeName(UseSelectOptionsTemplate.TemplateId, template.Model);
        }

        public static string GetUseSelectOptionsName(this IIntentTemplate template, SelectModel model)
        {
            return template.GetTypeName(UseSelectOptionsTemplate.TemplateId, model);
        }
        public static string GetUseTableOptionsName<T>(this IIntentTemplate<T> template) where T : TableModel
        {
            return template.GetTypeName(UseTableOptionsTemplate.TemplateId, template.Model);
        }

        public static string GetUseTableOptionsName(this IIntentTemplate template, TableModel model)
        {
            return template.GetTypeName(UseTableOptionsTemplate.TemplateId, model);
        }
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

        public static string GetModelsName<T>(this IIntentTemplate<T> template) where T : ComponentModel
        {
            return template.GetTypeName(ModelsTemplate.TemplateId, template.Model);
        }

        public static string GetModelsName(this IIntentTemplate template, ComponentModel model)
        {
            return template.GetTypeName(ModelsTemplate.TemplateId, model);
        }

        public static string GetPropsName<T>(this IIntentTemplate<T> template) where T : ComponentModel
        {
            return template.GetTypeName(PropsTemplate.TemplateId, template.Model);
        }

        public static string GetPropsName(this IIntentTemplate template, ComponentModel model)
        {
            return template.GetTypeName(PropsTemplate.TemplateId, model);
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