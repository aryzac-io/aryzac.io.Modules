using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace Aryzac.IO.Client.Nuxt.Templates.Files.Pages.PageI18n
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class PageI18nTemplate : IntentTemplateBase<PageModel>, IDataFileBuilderTemplate
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Aryzac.IO.Client.Nuxt.Files.Pages.Page i18n";

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
                            .WithObject(locale.Name, localeObject =>
                            {
                                if (Model.BreadcrumbNavigation is not null)
                                {
                                    AddModelBreadcrumbNavigation(localeObject, Model.BreadcrumbNavigation, locale);
                                }
                                else
                                {
                                    AddPlaceholder(localeObject);
                                }
                            });
                    }
                });
        }

        private void AddModelBreadcrumbNavigation(IDataFileObjectValue yamlObject, PageBreadcrumbNavigationModel model, LocaleModel locale)
        {
            yamlObject.WithObject("breadcrumb", breadcrumbObject =>
            {
                breadcrumbObject.WithObject("navigation", navigationObject =>
                {
                    foreach (var item in model.Items)
                    {
                        AddModelBreadcrumbNavigationItem(navigationObject, item, locale);
                    }

                    if (model.Items.Count == 0)
                    {
                        AddPlaceholder(yamlObject);
                    }
                });
            });
        }

        private static void AddModelBreadcrumbNavigationItem(IDataFileObjectValue yamlObject, NavigationItemModel model, LocaleModel locale)
        {
            var navigationSettings = model.GetNavigationItemSettingss().FirstOrDefault(s => s.Locale().Name == locale.Name);

            yamlObject.WithObject(model.Name.ToPascalCase().ToCamelCase(), itemObject =>
            {
                itemObject.WithValue("label", navigationSettings?.Label() ?? model.Name);

                if (navigationSettings?.Icon() != null)
                {
                    itemObject.WithValue("icon", navigationSettings?.Icon());
                }
            });
        }

        private static void AddPlaceholder(IDataFileObjectValue localeObject)
        {
            localeObject.WithValue("placeholder", "''");
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

        [IntentManaged(Mode.Fully)]
        public IDataFile DataFile { get; }

        [IntentManaged(Mode.Fully)]
        public override ITemplateFileConfig GetTemplateFileConfig() => DataFile.GetConfig();

        [IntentManaged(Mode.Fully)]
        public override string TransformText() => DataFile.ToString();
    }
}