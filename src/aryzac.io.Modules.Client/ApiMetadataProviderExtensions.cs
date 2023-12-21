using System.Collections.Generic;
using System.Linq;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiMetadataProviderExtensions", Version = "1.0")]

namespace Aryzac.Io.Modules.Client.Api
{
    public static class ApiMetadataProviderExtensions
    {
        public static IList<CommonTypesModel> GetCommonTypesModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(CommonTypesModel.SpecializationTypeId)
                .Select(x => new CommonTypesModel(x))
                .ToList();
        }

        public static IList<ComponentsModel> GetComponentsModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(ComponentsModel.SpecializationTypeId)
                .Select(x => new ComponentsModel(x))
                .ToList();
        }

        public static IList<LayoutsModel> GetLayoutsModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(LayoutsModel.SpecializationTypeId)
                .Select(x => new LayoutsModel(x))
                .ToList();
        }

        public static IList<PagesModel> GetPagesModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(PagesModel.SpecializationTypeId)
                .Select(x => new PagesModel(x))
                .ToList();
        }

        public static IList<ServiceProxiesModel> GetServiceProxiesModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(ServiceProxiesModel.SpecializationTypeId)
                .Select(x => new ServiceProxiesModel(x))
                .ToList();
        }

    }
}