using System;
using System.Collections.Generic;
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

namespace Aryzac.IO.Client.Nuxt.Templates.Files.Structs.Components.Props
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public partial class PropsTemplate : TypeScriptTemplateBase<Aryzac.IO.Modules.Client.Api.ComponentModel>, ITypescriptFileBuilderTemplate
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Aryzac.IO.Client.Nuxt.Files.Structs.Components.Props";

        [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
        public PropsTemplate(IOutputTarget outputTarget, ComponentModel model) : base(TemplateId, outputTarget, model)
        {
            Types = new TypeScriptTypeResolver();

            TypescriptFile = new TypescriptFile(this.GetFolderPath())
                .AddInterface($"{Model.Name.ToPascalCase()}Props", @interface =>
                {
                    @interface.Export();

                    foreach (var parameter in Model.Parameters)
                    {
                        @interface.AddField(parameter.Name.ToPascalCase().ToCamelCase(), GetTypeName(parameter.TypeReference));
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
                fileName: $"{Model.Name.ToKebabCase()}.props",
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