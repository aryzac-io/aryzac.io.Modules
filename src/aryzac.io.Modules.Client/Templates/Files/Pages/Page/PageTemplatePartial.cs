using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Aryzac.IO.Modules.Client.Api;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.ProjectItemTemplate.Partial", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Templates.Files.Pages.Page
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    partial class PageTemplate : IntentTemplateBase<PageModel>
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Aryzac.IO.Modules.Client.Files.Pages.Page";

        [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
        public PageTemplate(IOutputTarget outputTarget, PageModel model) : base(TemplateId, outputTarget, model)
        {
            foreach (var pageComponent in model.PageComponents)
            {
                var i = (IElement)pageComponent.TypeReference.Element;

                while (i != null)
                {
                    Debug.WriteLine(i.Name);

                    i = i.ParentElement;

                    if (i.SpecializationType == "Components")
                    {
                        break;
                    }
                }

                var o = pageComponent.TypeReference.Element.Name.ToKebabCase();
            }
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public override ITemplateFileConfig GetTemplateFileConfig()
        {
            return new TemplateFileConfig(
                fileName: $"{Model.GetPath()}/{Model.Name}",
                fileExtension: "vue"
            );
        }

        public string GetPageComponentName(PageComponentModel pageComponent)
        {
            var element = (IElement)pageComponent.TypeReference.Element;
            var elementPath = new List<string>();

            while (element != null)
            {
                elementPath.Add(element.Name.ToKebabCase());

                element = element.ParentElement;

                if (element.SpecializationType == "Components")
                {
                    break;
                }
            }

            return string.Join("-", elementPath.Reverse<string>());
        }

    }
}