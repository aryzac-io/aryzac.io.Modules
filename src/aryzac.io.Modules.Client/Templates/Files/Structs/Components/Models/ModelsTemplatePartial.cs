using System;
using System.Collections.Generic;
using System.Linq;
using Aryzac.IO.Modules.Client.Api;
using Intent.Engine;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.TypeScript.Builder;
using Intent.Modules.Common.TypeScript.Templates;
using Intent.Modules.Common.TypeScript.TypeResolvers;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.TypeScript.Templates.TypescriptTemplatePartial", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Templates.Files.Structs.Components.Models
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public partial class ModelsTemplate : TypeScriptTemplateBase<Aryzac.IO.Modules.Client.Api.ComponentModel>, ITypescriptFileBuilderTemplate
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Aryzac.IO.Modules.Client.Files.Structs.Components.Models";

        [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
        public ModelsTemplate(IOutputTarget outputTarget, Aryzac.IO.Modules.Client.Api.ComponentModel model) : base(TemplateId, outputTarget, model)
        {
            Types = new TypeScriptTypeResolver();

            TypescriptFile = new TypescriptFile(this.GetFolderPath())
                .AddInterface($"{Model.Name}Model", @interface =>
                {
                    @interface.Export();

                    if (Model.Model?.Properties is not null)
                        foreach (var property in Model.Model.Properties)
                        {
                            @interface.AddField(property.Name.ToPascalCase().ToCamelCase(), GetTypeName(property.TypeReference));
                        }
                });
        }

        [IntentManaged(Mode.Fully)]
        public TypescriptFile TypescriptFile { get; }

        [IntentManaged(Mode.Fully)]
        public override ITemplateFileConfig GetTemplateFileConfig()
        {
            return new TypeScriptFileConfig(
                overwriteBehaviour: OverwriteBehaviour.Always,
                fileName: $"{Model.Name.ToKebabCase()}.model",
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