using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Xml.Linq;
using Aryzac.IO.Modules.Client.Api;
using Aryzac.IO.Client.Nuxt.Templates.Files.Components.Shared;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.Modelers.Types.ServiceProxies.Api;
using Intent.Modelers.WebClient.Api;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.TypeScript.TypeResolvers;
using Intent.Modules.Metadata.WebApi.Models;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.ProjectItemTemplate.Partial", Version = "1.0")]

namespace Aryzac.IO.Client.Nuxt.Templates.Files.Components.Component
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public partial class ComponentTemplate : IntentTemplateBase<ComponentModel>
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Aryzac.IO.Client.Nuxt.Files.Components.Component";

        [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
        public ComponentTemplate(IOutputTarget outputTarget, ComponentModel model) : base(TemplateId, outputTarget, model)
        {
            Types = new TypeScriptTypeResolver();

            htmlTemplate = new HtmlTemplate(model.InternalElement);
            GetAllComposables();
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public override ITemplateFileConfig GetTemplateFileConfig()
        {
            return new TemplateFileConfig(
                fileName: $"{Model.GetPath()}/{Model.Name.ToKebabCase()}",
                fileExtension: "vue"
            );
        }

        private HtmlTemplate htmlTemplate;
        public string HtmlTemplate => htmlTemplate.TransformText();

        public List<ComponentQueryModel> Queries => Model.InternalElement.ChildElements
            .GetElementsOfType(ComponentQueryModel.SpecializationTypeId, true)
            .Select(x => new ComponentQueryModel(x))
            .Where(m => m.Mapping is not null)
            .ToList();

        public List<ComponentCommandModel> Commands => Model.InternalElement.ChildElements
            .GetElementsOfType(ComponentCommandModel.SpecializationTypeId, true)
            .Select(x => new ComponentCommandModel(x))
            .Where(m => m.Mapping is not null)
            .ToList();

        public List<ServiceProxyModel> CommandsAndQueries
        {
            get
            {
                var commands = Model.InternalElement.ChildElements
                    .GetElementsOfType(ComponentCommandModel.SpecializationTypeId, true)
                    .Select(x => new ComponentCommandModel(x));

                var queries = Model.InternalElement.ChildElements
                    .GetElementsOfType(ComponentQueryModel.SpecializationTypeId, true)
                    .Select(x => new ComponentQueryModel(x));

                var response = new List<ServiceProxyModel>();
                if (commands is not null)
                    response.AddRange(commands.Select(m => m.Mapping?.Element.AsOperationModel().ParentService));
                if (queries is not null)
                    response.AddRange(queries.Select(m => m.Mapping?.Element.AsOperationModel().ParentService));

                return response.Where(m => m is not null).Distinct().ToList();
            }
        }
        public IEnumerable<IElement> GetAllComposables()
        {
            var specializationTypes = new List<string>()
            {
                HeadingModel.SpecializationTypeId,
                LabelModel.SpecializationTypeId,
                SelectModel.SpecializationTypeId,
                TableModel.SpecializationTypeId,
                
                // No option composables exist for these types (yet)
                //SectionModel.SpecializationTypeId,
                //TextboxModel.SpecializationTypeId,
                //CheckboxModel.SpecializationTypeId,
                //RadioButtonModel.SpecializationTypeId,
                //TextAreaModel.SpecializationTypeId,
            };

            var controls = Model.InternalElement.ChildElements
                .GetMatchedElements(m => specializationTypes.Contains(m.SpecializationTypeId), true);

            return controls;
        }

        public string GetComposableMethodParameters(IElement element)
        {
            var functionParameters = new List<string>();

            if (Model.InternalElement.ChildElements.GetElementsOfType(ComponentParameterModel.SpecializationTypeId, true).Any())
            {
                functionParameters.Add($"props");
            }

            if (Model.InternalElement.ChildElements.GetElementsOfType(ComponentModelModel.SpecializationTypeId, true).Any())
            {
                functionParameters.Add($"model");
            }

            return string.Join(", ", functionParameters);
        }
    }
}