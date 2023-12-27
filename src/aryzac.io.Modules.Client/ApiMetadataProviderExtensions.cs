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

        public static IList<BaseStyleModel> GetBaseStyleModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(BaseStyleModel.SpecializationTypeId)
                .Select(x => new BaseStyleModel(x))
                .ToList();
        }

        public static IList<BreakpointsModel> GetBreakpointsModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(BreakpointsModel.SpecializationTypeId)
                .Select(x => new BreakpointsModel(x))
                .ToList();
        }

        public static IList<ButtonModel> GetButtonModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(ButtonModel.SpecializationTypeId)
                .Select(x => new ButtonModel(x))
                .ToList();
        }

        public static IList<ColorsModel> GetColorsModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(ColorsModel.SpecializationTypeId)
                .Select(x => new ColorsModel(x))
                .ToList();
        }

        public static IList<CommandsModel> GetCommandsModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(CommandsModel.SpecializationTypeId)
                .Select(x => new CommandsModel(x))
                .ToList();
        }
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

        public static IList<ContainersModel> GetContainersModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(ContainersModel.SpecializationTypeId)
                .Select(x => new ContainersModel(x))
                .ToList();
        }

        public static IList<ControlsModel> GetControlsModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(ControlsModel.SpecializationTypeId)
                .Select(x => new ControlsModel(x))
                .ToList();
        }

        public static IList<DataControlsModel> GetDataControlsModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(DataControlsModel.SpecializationTypeId)
                .Select(x => new DataControlsModel(x))
                .ToList();
        }

        public static IList<DataSourceModel> GetDataSourceModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(DataSourceModel.SpecializationTypeId)
                .Select(x => new DataSourceModel(x))
                .ToList();
        }

        public static IList<FlexModel> GetFlexModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(FlexModel.SpecializationTypeId)
                .Select(x => new FlexModel(x))
                .ToList();
        }

        public static IList<FontModel> GetFontModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(FontModel.SpecializationTypeId)
                .Select(x => new FontModel(x))
                .ToList();
        }

        public static IList<FormDefinitionModel> GetFormDefinitionModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(FormDefinitionModel.SpecializationTypeId)
                .Select(x => new FormDefinitionModel(x))
                .ToList();
        }

        public static IList<FormDefinitionReferenceModel> GetFormDefinitionReferenceModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(FormDefinitionReferenceModel.SpecializationTypeId)
                .Select(x => new FormDefinitionReferenceModel(x))
                .ToList();
        }

        public static IList<FormInputsModel> GetFormInputsModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(FormInputsModel.SpecializationTypeId)
                .Select(x => new FormInputsModel(x))
                .ToList();
        }

        public static IList<LayoutTemplateModel> GetLayoutTemplateModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(LayoutTemplateModel.SpecializationTypeId)
                .Select(x => new LayoutTemplateModel(x))
                .ToList();
        }

        public static IList<LayoutsModel> GetLayoutsModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(LayoutsModel.SpecializationTypeId)
                .Select(x => new LayoutsModel(x))
                .ToList();
        }

        public static IList<ModifiersModel> GetModifiersModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(ModifiersModel.SpecializationTypeId)
                .Select(x => new ModifiersModel(x))
                .ToList();
        }

        public static IList<NavigationControlsModel> GetNavigationControlsModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(NavigationControlsModel.SpecializationTypeId)
                .Select(x => new NavigationControlsModel(x))
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

        public static IList<StyleModel> GetStyleModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(StyleModel.SpecializationTypeId)
                .Select(x => new StyleModel(x))
                .ToList();
        }

        public static IList<StylesModel> GetStylesModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(StylesModel.SpecializationTypeId)
                .Select(x => new StylesModel(x))
                .ToList();
        }

        public static IList<TextModel> GetTextModels(this IDesigner designer)
        {
            return designer.GetElementsOfType(TextModel.SpecializationTypeId)
                .Select(x => new TextModel(x))
                .ToList();
        }

    }
}