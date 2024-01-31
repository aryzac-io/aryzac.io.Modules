using System.Collections.Generic;
using System.Linq;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiMetadataProviderExtensions", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Api
{
    public static class ApiMetadataProviderExtensions
    {
        public static IList<ComponentsModel> GetComponentsModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(ComponentsModel.SpecializationTypeId)
                .Select(x => new ComponentsModel(x))
                .ToList();
        }

        public static IList<ControlsModel> GetControlsModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(ControlsModel.SpecializationTypeId)
                .Select(x => new ControlsModel(x))
                .ToList();
        }

        public static IList<ComponentModel> GetComponentModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(ComponentModel.SpecializationTypeId)
                .Select(x => new ComponentModel(x))
                .ToList();
        }

        public static IList<LayoutsModel> GetLayoutsModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(LayoutsModel.SpecializationTypeId)
                .Select(x => new LayoutsModel(x))
                .ToList();
        }

        public static IList<LocalesModel> GetLocalesModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(LocalesModel.SpecializationTypeId)
                .Select(x => new LocalesModel(x))
                .ToList();
        }

        public static IList<LayoutModel> GetLayoutModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(LayoutModel.SpecializationTypeId)
                .Select(x => new LayoutModel(x))
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

        public static IList<PackageExtensionModel> GetPackageExtensionModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(PackageExtensionModel.SpecializationTypeId)
                .Select(x => new PackageExtensionModel(x.Package))
                .ToList();
        }

        public static IList<PageModel> GetPageModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(PageModel.SpecializationTypeId)
                .Select(x => new PageModel(x))
                .ToList();
        }

        public static IList<TableModel> GetTableModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(TableModel.SpecializationTypeId)
                .Select(x => new TableModel(x))
                .ToList();
        }

    }
}