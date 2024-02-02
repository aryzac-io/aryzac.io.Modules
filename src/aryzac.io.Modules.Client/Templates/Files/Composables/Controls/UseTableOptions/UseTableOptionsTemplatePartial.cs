using System;
using System.Collections.Generic;
using System.Linq;
using Aryzac.IO.Modules.Client.Api;
using Aryzac.IO.Modules.Client.Templates.Files.Composables.Controls.Shared;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.Modelers.Types.ServiceProxies.Api;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.TypeScript.Templates;
using Intent.Modules.Common.TypeScript.TypeResolvers;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.TypeScript.Templates.TypescriptTemplatePartial", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Templates.Files.Composables.Controls.UseTableOptions
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    partial class UseTableOptionsTemplate : TypeScriptTemplateBase<Aryzac.IO.Modules.Client.Api.TableModel>
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Aryzac.IO.Modules.Client.Files.Composables.Controls.UseTableOptions";

        [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
        public UseTableOptionsTemplate(IOutputTarget outputTarget, Aryzac.IO.Modules.Client.Api.TableModel model) : base(TemplateId, outputTarget, model)
        {
            Types = new TypeScriptTypeResolver();
            
            commandAndQueryServiceProxyComposables = new CommandAndQueryServiceProxyComposables(model.InternalElement);
            commands = new Commands(model.InternalElement, GetTypeName);

            dtoTypeImports = new DtoTypeImports(model.InternalElement);
            tableHeaders = new TableHeaders(model.InternalElement);
            tableActions = new TableActions(model.InternalElement);
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public override ITemplateFileConfig GetTemplateFileConfig()
        {
            return new TypeScriptFileConfig(
                className: $"{Model.Name}",
                fileName: $"components/{Model.GetPath()}/use{Model.InternalElement.GetFirstParentOfType(ComponentModel.SpecializationTypeId).Name.ToPascalCase()}{Model.Name.ToPascalCase()}Options"
            );
        }

        private TableHeaders tableHeaders;
        public string TableHeaders => tableHeaders.TransformText();

        private TableActions tableActions;
        public string TableActions => tableActions.TransformText();

        private CommandAndQueryServiceProxyComposables commandAndQueryServiceProxyComposables;
        public string CommandAndQueryServiceProxyComposables => commandAndQueryServiceProxyComposables.TransformText();

        private Commands commands;
        public string Commands => commands.TransformText();

        private DtoTypeImports dtoTypeImports;
        public string DtoTypeImports => dtoTypeImports.TransformText();
    }
}