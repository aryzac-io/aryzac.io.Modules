using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Aryzac.IO.Modules.Client.Api;
using Aryzac.IO.Client.Nuxt.Templates.Files.Composables.Controls.Shared;
using Intent.Engine;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.TypeScript.Templates;
using Intent.Modules.Common.TypeScript.TypeResolvers;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.TypeScript.Templates.TypescriptTemplatePartial", Version = "1.0")]

namespace Aryzac.IO.Client.Nuxt.Templates.Files.Composables.Controls.UseHeadingOptions
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    partial class UseHeadingOptionsTemplate : TypeScriptTemplateBase<Aryzac.IO.Modules.Client.Api.HeadingModel>
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Aryzac.IO.Client.Nuxt.Files.Composables.Controls.UseHeadingOptions";

        [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
        public UseHeadingOptionsTemplate(IOutputTarget outputTarget, HeadingModel model) : base(TemplateId, outputTarget, model)
        {
            Types = new TypeScriptTypeResolver();

            dtoTypeImports = new DtoTypeImports(model.InternalElement);
            commandAndQueryServiceProxyComposables = new CommandAndQueryServiceProxyComposables(model.InternalElement);

            titleComputed = new TitleComputed(model.InternalElement);
            attributes = new Attributes(model.InternalElement);

            commands = new Commands(model.InternalElement, GetTypeName);

            actions = new Actions(model.InternalElement);
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public override ITemplateFileConfig GetTemplateFileConfig()
        {
            return new TypeScriptFileConfig(
                className: $"{Model.Name}",
                fileName: $"components/{Model.GetPath()}/use{Model.InternalElement.GetFirstParentOfType(ComponentModel.SpecializationTypeId).Name.ToPascalCase()}{Model.Name.ToPascalCase()}Options"
            );
        }

        private DtoTypeImports dtoTypeImports;
        public string DtoTypeImports => dtoTypeImports.TransformText();

        private CommandAndQueryServiceProxyComposables commandAndQueryServiceProxyComposables;
        public string CommandAndQueryServiceProxyComposables => commandAndQueryServiceProxyComposables.TransformText();

        private TitleComputed titleComputed;
        public string TitleComputed => titleComputed.TransformText();

        private Attributes attributes;
        public string Attributes => attributes.TransformText();

        public bool HasAttributes()
        {
            var heading = Model.InternalElement.AsHeadingModel();
            if (heading.Attributes is null) return false;

            return heading.Attributes.Any();
        }

        private Commands commands;
        public string Commands => commands.TransformText();

        private IEnumerable<ComponentCommandModel> HeadingCommands()
        {
            return Model.InternalElement.ChildElements
                .GetElementsOfType(ComponentCommandModel.SpecializationTypeId, true)
                .Select(x => new ComponentCommandModel(x))
                .ToList();
        }

        private Actions actions;
        public string Actions => actions.TransformText();

        public bool HasActions()
        {
            var heading = Model.InternalElement.AsHeadingModel();
            if (heading.Actions is null) return false;

            return heading.Actions.Actions.Any();
        }

        public ComponentModel GetComponent()
        {
            return Model.InternalElement.GetFirstParentOfType(ComponentModel.SpecializationTypeId).AsComponentModel();
        }

        public string GetMethodSignature()
        {
            var functionParameters = new Dictionary<string, string>();

            if (GetComponent().Parameters.Any())
            {
                functionParameters.Add("props", $"{GetComponent().Name.ToPascalCase()}Props");
            }

            if (GetComponent().Model != null)
            {
                functionParameters.Add("model", $"{GetComponent().Name.ToPascalCase()}Model");
            }

            return string.Join(", ", functionParameters.Select(kv => $"{kv.Key}: {kv.Value}"));
        }
    }
}