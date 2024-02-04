using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.Modules.Common.FileBuilders.DataFileBuilder;
using Intent.Modules.Common.Templates;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.ProjectItemTemplate.Partial", Version = "1.0")]

namespace Aryzac.IO.Client.Nuxt.Templates.Files.Package
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class PackageTemplate : IntentTemplateBase<object>, IDataFileBuilderTemplate
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Aryzac.IO.Client.Nuxt.Files.package";

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public PackageTemplate(IOutputTarget outputTarget, object model = null) : base(TemplateId, outputTarget, model)
        {
            DataFile = new DataFile($"package")
                .WithJsonWriter()
                .WithRootObject(this, @object =>
                {
                    @object
                        .WithValue("name", "nuxt-app")
                        .WithValue("private", true)
                        .WithValue("type", "module")
                        .WithObject("scripts", scripts =>
                        {
                            scripts
                                .WithValue("build", "nuxt build")
                                .WithValue("dev", "nuxt dev")
                                .WithValue("generate", "nuxt generate")
                                .WithValue("preview", "nuxt preview")
                                .WithValue("postinstall", "nuxt prepare");
                        })
                        .WithObject("devDependencies", devDependencies =>
                        {
                            devDependencies
                                .WithValue("@headlessui/vue", "1.7.16")
                                .WithValue("@nuxtjs/i18n", "8.0.0")
                                .WithValue("@nuxtjs/tailwindcss", "6.10.3")
                                .WithValue("@nuxtseo/module", "2.0.0-beta.55")
                                .WithValue("@tailwindcss/forms", "0.5.7")
                                .WithValue("@tailwindcss/typography", "0.5.10")
                                .WithValue("nuxt", "3.9.0")
                                .WithValue("nuxt-icon", "0.6.8")
                                .WithValue("vue", "3.4.3")
                                .WithValue("vue-router", "4.2.5")
                                .WithValue("typescript", "5.3.3");
                        })
                        .WithObject("dependencies", dependencies =>
                        {
                            dependencies
                                .WithValue("@pinia/nuxt", "0.5.1")
                                .WithValue("pinia", "2.1.7");
                        })
                        .WithObject("resolutions", resolutions =>
                        {
                            resolutions
                                .WithValue("string-width", "4.2.3");
                        });
                });
        }

        [IntentManaged(Mode.Fully)]
        public IDataFile DataFile { get; }

        [IntentManaged(Mode.Fully)]
        public override ITemplateFileConfig GetTemplateFileConfig() => DataFile.GetConfig();

        [IntentManaged(Mode.Fully)]
        public override string TransformText() => DataFile.ToString();
    }
}