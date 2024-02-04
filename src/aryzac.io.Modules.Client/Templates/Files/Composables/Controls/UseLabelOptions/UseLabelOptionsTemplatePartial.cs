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

namespace Aryzac.IO.Modules.Client.Templates.Files.Composables.Controls.UseLabelOptions
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    partial class UseLabelOptionsTemplate : TypeScriptTemplateBase<Aryzac.IO.Modules.Client.Api.LabelModel>
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Aryzac.IO.Modules.Client.Files.Composables.Controls.UseLabelOptions";

        [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
        public UseLabelOptionsTemplate(IOutputTarget outputTarget, Aryzac.IO.Modules.Client.Api.LabelModel model) : base(TemplateId, outputTarget, model)
        {
            Types = new TypeScriptTypeResolver();

            dtoTypeImports = new DtoTypeImports(model.InternalElement);
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