using System;
using System.Collections.Generic;
using System.Linq;
using Aryzac.IO.Modules.Client.Api;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.Modelers.WebClient.Api;
using Intent.Modules.Common;
using Intent.Modules.Common.FileBuilders.DataFileBuilder;
using Intent.Modules.Common.Templates;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.ProjectItemTemplate.Partial", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Templates.Files.Pages.PageI18n
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class PageI18nTemplate : IntentTemplateBase<PageModel>, IDataFileBuilderTemplate
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Aryzac.IO.Modules.Client.Files.Pages.Page i18n";

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public PageI18nTemplate(IOutputTarget outputTarget, PageModel model) : base(TemplateId, outputTarget, model)
        {
            DataFile = new DataFile($"{Model.GetPath()}.i18n")
                .WithYamlWriter()
                .WithRootObject(this, @object =>
                {
                    foreach (var locale in GetLocales()[0].Locales)
                    {
                        @object
                            .WithObject(locale.Name, l =>
                            {
                                AddModelBreadcrumbNavigation(l, locale);
                            });
                    }
                });
        }

        public IList<LocalesModel> GetLocales()
        {
            return ExecutionContext.MetadataManager.WebClient(ExecutionContext.GetApplicationConfig().Id).GetLocalesModels().ToList();
        }

        public LocaleModel GetDefaultLocale()
        {
            foreach (var locale in GetLocales()[0].Locales)
            {
                locale.TryGetDefaultLocale(out var defaultLocaleSettings);

                if (defaultLocaleSettings is not null)
                {
                    return locale;
                }
            }

            throw new NotSupportedException("No default locale has been set. Please set a default locale.");
        }

        public bool IsDefaultLocale(LocaleModel locale)
        {
            return locale == GetDefaultLocale();
        }

        private void AddModelBreadcrumbNavigation(IDataFileObjectValue en, LocaleModel locale)
        {
            if (Model.BreadcrumbNavigation is not null)
            {
                en.WithObject("breadcrumb", breadcrumbObj =>
                {
                    breadcrumbObj.WithObject("navigation", navigationObj =>
                    {
                        foreach (var item in Model.BreadcrumbNavigation.Items)
                        {
                            var navigationSettings = item.GetNavigationItemSettingss().FirstOrDefault(s => s.Locale().Name == locale.Name);

                            navigationObj.WithObject(item.Name.ToPascalCase().ToCamelCase(), itemObj =>
                            {
                                itemObj.WithValue("label", navigationSettings?.Label() ?? item.Name);

                                if (navigationSettings?.Icon() != null)
                                {
                                    itemObj.WithValue("icon", navigationSettings?.Icon());
                                }
                            });
                        }
                    });
                });
            }
        }

        [IntentManaged(Mode.Fully)]
        public IDataFile DataFile { get; }

        [IntentManaged(Mode.Fully)]
        public override ITemplateFileConfig GetTemplateFileConfig() => DataFile.GetConfig();

        [IntentManaged(Mode.Fully)]
        public override string TransformText() => DataFile.ToString();
    }
}