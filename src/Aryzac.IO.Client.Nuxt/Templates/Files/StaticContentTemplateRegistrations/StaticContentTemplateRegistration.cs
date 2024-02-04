using System.Collections.Generic;
using Intent.Engine;
using Intent.Modules.Common.Templates.StaticContent;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.StaticContentTemplateRegistration", Version = "1.0")]

namespace Aryzac.IO.Client.Nuxt.Templates.Files.StaticContentTemplateRegistrations
{
    public class StaticContentTemplateRegistration : Intent.Modules.Common.Templates.StaticContent.StaticContentTemplateRegistration
    {
        public new const string TemplateId = "Aryzac.IO.Client.Nuxt.Templates.Files.StaticContentTemplateRegistrations.StaticContentTemplateRegistration";

        public StaticContentTemplateRegistration() : base(TemplateId)
        {
        }


        public override string[] BinaryFileGlobbingPatterns => new string[] { "*.jpg", "*.png", "*.xlsx", "*.ico", "*.pdf" };


        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public override IReadOnlyDictionary<string, string> Replacements(IOutputTarget outputTarget) => new Dictionary<string, string>
        {
        };
    }
}