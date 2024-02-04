using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Aryzac.IO.Modules.Client.Api;
using Aryzac.IO.Client.Nuxt.Templates.Files.Composables.Controls.Shared;
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

namespace Aryzac.IO.Client.Nuxt.Templates.Files.Composables.Controls.UseTableOptions
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    partial class UseTableOptionsTemplate : TypeScriptTemplateBase<Aryzac.IO.Modules.Client.Api.TableModel>
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Aryzac.IO.Client.Nuxt.Files.Composables.Controls.UseTableOptions";

        [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
        public UseTableOptionsTemplate(IOutputTarget outputTarget, TableModel model) : base(TemplateId, outputTarget, model)
        {
            Types = new TypeScriptTypeResolver();

            commandAndQueryServiceProxyComposables = new CommandAndQueryServiceProxyComposables(model.InternalElement);
            queries = new Queries(model.InternalElement);
            commands = new Commands(model.InternalElement, GetTypeName);

            dtoTypeImports = new DtoTypeImports(model.InternalElement);
            tableHeaders = new TableHeaders(model.InternalElement);
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

        private Queries queries;
        public string Queries => queries.TransformText();

        private bool HasQueries()
        {
            return Model.InternalElement.ChildElements
                .GetElementsOfType(ComponentQueryModel.SpecializationTypeId, true)
                .Any();
        }

        private Commands commands;
        public string Commands => commands.TransformText();

        private IEnumerable<ComponentCommandModel> TableCommands()
        {
            return Model.InternalElement.ChildElements
                .GetElementsOfType(ComponentCommandModel.SpecializationTypeId, true)
                .Select(x => new ComponentCommandModel(x))
                .ToList();
        }

        private DtoTypeImports dtoTypeImports;
        public string DtoTypeImports => dtoTypeImports.TransformText();

        private TableHeaders tableHeaders;
        public string TableHeaders => tableHeaders.TransformText();

        public bool HasHeaders()
        {
            var table = Model.InternalElement.AsTableModel();
            return table.Columns.Any();
        }

        private Actions actions;
        public string Actions => actions.TransformText();

        public bool HasActions()
        {
            var table = Model.InternalElement.AsTableModel();
            if (table.Actions is null) return false;

            return table.Actions.Actions.Any();
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