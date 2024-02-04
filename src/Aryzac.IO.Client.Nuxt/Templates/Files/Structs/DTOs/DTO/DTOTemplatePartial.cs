using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.Modelers.Services.Api;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.TypeScript.Builder;
using Intent.Modules.Common.TypeScript.Templates;
using Intent.Modules.Common.TypeScript.TypeResolvers;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.TypeScript.Templates.TypescriptTemplatePartial", Version = "1.0")]

namespace Aryzac.IO.Client.Nuxt.Templates.Files.Structs.DTOs.DTO
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public partial class DTOTemplate : TypeScriptTemplateBase<Intent.Modelers.Services.Api.DTOModel>, ITypescriptFileBuilderTemplate
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Aryzac.IO.Client.Nuxt.Files.Structs.DTOs.DTO";

        [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
        public DTOTemplate(IOutputTarget outputTarget, Intent.Modelers.Services.Api.DTOModel model) : base(TemplateId, outputTarget, model)
        {
            Types = new TypeScriptTypeResolver();

            TypescriptFile = new TypescriptFile(this.GetFolderPath())
                .AddInterface($"{Model.Name}{GenericTypes}", @interface =>
                {
                    @interface.Export();

                    foreach (var field in Model.Fields)
                    {
                        @interface.AddField(field.Name.ToPascalCase().ToCamelCase(), GetTypeName(field.TypeReference));
                    }
                });
        }

        public string GenericTypes => Model.GenericTypes.Any() ? $"<{string.Join(", ", Model.GenericTypes)}>" : "";

        [IntentManaged(Mode.Fully)]
        public TypescriptFile TypescriptFile { get; }

        [IntentManaged(Mode.Fully)]
        public override ITemplateFileConfig GetTemplateFileConfig()
        {
            return new TypeScriptFileConfig(
                overwriteBehaviour: OverwriteBehaviour.Always,
                fileName: $"{Model.Name.ToKebabCase().RemoveSuffix("-dto")}.dto",
                relativeLocation: $"{Model.InternalElement.ParentElement.Name.ToPascalCase().ToCamelCase()}",
                className: $"{Model.Name}"
            );
        }

        [IntentManaged(Mode.Fully)]
        public override string TransformText()
        {
            return TypescriptFile.ToString();
        }
    }
}