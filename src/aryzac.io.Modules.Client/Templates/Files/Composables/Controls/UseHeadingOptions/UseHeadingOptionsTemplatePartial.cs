using System;
using System.Collections.Generic;
using System.Linq;
using Aryzac.IO.Modules.Client.Api;
using Aryzac.IO.Modules.Client.Templates.Files.Composables.Controls.Shared;
using Intent.Engine;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.TypeScript.Templates;
using Intent.Modules.Common.TypeScript.TypeResolvers;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.TypeScript.Templates.TypescriptTemplatePartial", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Templates.Files.Composables.Controls.UseHeadingOptions
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    partial class UseHeadingOptionsTemplate : TypeScriptTemplateBase<Aryzac.IO.Modules.Client.Api.HeadingModel>
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Aryzac.IO.Modules.Client.Files.Composables.Controls.UseHeadingOptions";

        [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
        public UseHeadingOptionsTemplate(IOutputTarget outputTarget, Aryzac.IO.Modules.Client.Api.HeadingModel model) : base(TemplateId, outputTarget, model)
        {
            Types = new TypeScriptTypeResolver();

            commandAndQueryServiceProxyComposables = new CommandAndQueryServiceProxyComposables(model.InternalElement);
            commands = new Commands(model.InternalElement, GetTypeName);
            dtoTypeImports = new DtoTypeImports(model.InternalElement);

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

        private CommandAndQueryServiceProxyComposables commandAndQueryServiceProxyComposables;
        public string CommandAndQueryServiceProxyComposables => commandAndQueryServiceProxyComposables.TransformText();

        private Commands commands;
        public string Commands => commands.TransformText();

        private IEnumerable<ComponentCommandModel> HeadingCommands()
        {
            return Model.InternalElement.ChildElements
                .GetElementsOfType(ComponentCommandModel.SpecializationTypeId, true)
                .Select(x => new ComponentCommandModel(x))
                .ToList();
        }

        private DtoTypeImports dtoTypeImports;
        public string DtoTypeImports => dtoTypeImports.TransformText();

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
    }
}