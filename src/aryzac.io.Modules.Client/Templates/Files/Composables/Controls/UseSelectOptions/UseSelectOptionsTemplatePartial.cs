using System;
using System.Collections.Generic;
using System.Linq;
using Aryzac.IO.Modules.Client.Api;
using Aryzac.IO.Modules.Client.Templates.Files.Composables.Controls.Shared;
using Aryzac.IO.Modules.Client.Templates.Files.Composables.Controls.UseSelectOptions;
using Intent.Engine;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.TypeScript.Templates;
using Intent.Modules.Common.TypeScript.TypeResolvers;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.TypeScript.Templates.TypescriptTemplatePartial", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Templates.Files.Composables.Controls.UseSelectOptions
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    partial class UseSelectOptionsTemplate : TypeScriptTemplateBase<Aryzac.IO.Modules.Client.Api.SelectModel>
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Aryzac.IO.Modules.Client.Files.Composables.Controls.UseSelectOptions";

        [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
        public UseSelectOptionsTemplate(IOutputTarget outputTarget, Aryzac.IO.Modules.Client.Api.SelectModel model) : base(TemplateId, outputTarget, model)
        {
            Types = new TypeScriptTypeResolver();

            commandAndQueryServiceProxyComposables = new CommandAndQueryServiceProxyComposables(model.InternalElement);
            queries = new Queries(model.InternalElement);
            dtoTypeImports = new DtoTypeImports(model.InternalElement);

            selectOptionsComputed = new SelectOptionsComputed(model.InternalElement);
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

        private Queries queries;
        public string Queries => queries.TransformText();

        private bool HasQueries()
        {
            return Model.InternalElement.ChildElements
                .GetElementsOfType(ComponentQueryModel.SpecializationTypeId, true)
                .Any();
        }

        private DtoTypeImports dtoTypeImports;
        public string DtoTypeImports => dtoTypeImports.TransformText();

        private SelectOptionsComputed selectOptionsComputed;
        public string SelectOptionsComputed => selectOptionsComputed.TransformText();
    }
}