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

namespace Aryzac.IO.Client.Nuxt.Templates.Files.Layouts.LayoutI18n
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class LayoutI18nTemplate : IntentTemplateBase<LayoutModel>, IDataFileBuilderTemplate
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Aryzac.IO.Client.Nuxt.Files.Layouts.Layout i18n";

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public LayoutI18nTemplate(IOutputTarget outputTarget, LayoutModel model) : base(TemplateId, outputTarget, model)
        {
            DataFile = new DataFile($"{Model.Name}.i18n")
                .WithYamlWriter()
                .WithRootObject(this, @object =>
                {
                    foreach (var locale in GetLocales()[0].Locales)
                    {
                        @object
                            .WithObject(locale.Name, localeObject =>
                            {
                                if (Model.TopNavigation is not null)
                                {
                                    AddModelTopNavigation(localeObject, Model.TopNavigation, locale);
                                }
                                if (Model.SidebarNavigation is not null)
                                {
                                    AddModelSidebarNavigation(localeObject, Model.SidebarNavigation, locale);
                                }
                                if (Model.BreadcrumbNavigation is not null)
                                {
                                    AddModelBreadcrumbNavigation(localeObject, Model.BreadcrumbNavigation, locale);
                                }

                                if (Model.TopNavigation is null && Model.SidebarNavigation is null && Model.BreadcrumbNavigation is null)
                                {
                                    AddPlaceholder(localeObject);
                                }
                            });
                    }
                });
        }

        private void AddModelTopNavigation(IDataFileObjectValue yamlObject, TopNavigationModel model, LocaleModel locale)
        {
            yamlObject.WithObject("appbar", appbarObject =>
            {
                appbarObject.WithObject("navigation", navigationObject =>
                {
                    foreach (var section in model.Sections)
                    {
                        AddModelTopSectionNavigation(navigationObject, section, locale);
                    }

                    if (model.Sections.Count == 0)
                    {
                        AddPlaceholder(navigationObject);
                    }
                });
            });
        }

        private static void AddModelTopSectionNavigation(IDataFileObjectValue yamlObject, TopNavigationSectionModel section, LocaleModel locale)
        {
            foreach (var item in section.Items)
            {
                AddModelTopSectionItemNavigation(yamlObject, item, locale);
            }

            if (section.Items.Count == 0)
            {
                AddPlaceholder(yamlObject);
            }
        }

        private static void AddModelTopSectionItemNavigation(IDataFileObjectValue yamlObject, NavigationItemModel item, LocaleModel locale)
        {
            var navigationSettings = item.GetNavigationItemSettingss().FirstOrDefault(s => s.Locale().Name == locale.Name);

            yamlObject.WithObject(item.Name.ToPascalCase().ToCamelCase(), itemObject =>
            {
                itemObject.WithValue("label", navigationSettings?.Label() ?? item.Name);

                if (navigationSettings?.Icon() != null)
                {
                    itemObject.WithValue("icon", navigationSettings.Icon());
                }
            });
        }

        private void AddModelSidebarNavigation(IDataFileObjectValue yamlObject, SidebarNavigationModel model, LocaleModel locale)
        {
            yamlObject.WithObject("sidebar", sidebarObject =>
            {
                sidebarObject.WithObject("navigation", navigationObject =>
                {
                    foreach (var section in model.Sections)
                    {
                        AddModelSidebarSectionNavigation(navigationObject, section, locale);
                    }

                    if (model.Sections.Count == 0)
                    {
                        AddPlaceholder(navigationObject);
                    }
                });
            });
        }

        private static void AddModelSidebarSectionNavigation(IDataFileObjectValue yamlObject, SidebarNavigationSectionModel section, LocaleModel locale)
        {
            yamlObject.WithObject(section.Name.ToPascalCase().ToCamelCase(), sectionObject =>
            {
                foreach (var item in section.Items)
                {
                    AddModelSidebarSectionItemNavigation(sectionObject, item, locale);
                }

                if (section.Items.Count == 0)
                {
                    AddPlaceholder(yamlObject);
                }
            });
        }

        private static void AddModelSidebarSectionItemNavigation(IDataFileObjectValue yamlObject, NavigationItemModel item, LocaleModel locale)
        {
            var navigationSettings = item.GetNavigationItemSettingss().FirstOrDefault(s => s.Locale().Name == locale.Name);

            yamlObject.WithObject(item.Name.ToPascalCase().ToCamelCase(), itemObject =>
            {
                itemObject.WithValue("label", navigationSettings?.Label() ?? item.Name);

                if (navigationSettings?.Icon() != null)
                {
                    itemObject.WithValue("icon", navigationSettings.Icon());
                }
            });
        }

        private void AddModelBreadcrumbNavigation(IDataFileObjectValue yamlObject, BreadcrumbNavigationModel model, LocaleModel locale)
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
                        AddPlaceholder(navigationObject);
                    }
                });
            });
        }

        private static void AddModelBreadcrumbNavigationItem(IDataFileObjectValue yamlObject, NavigationItemModel item, LocaleModel locale)
        {
            var navigationSettings = item.GetNavigationItemSettingss().FirstOrDefault(s => s.Locale().Name == locale.Name);

            yamlObject.WithObject(item.Name.ToPascalCase().ToCamelCase(), itemObject =>
            {
                itemObject.WithValue("label", navigationSettings?.Label() ?? item.Name);

                if (navigationSettings?.Icon() != null)
                {
                    itemObject.WithValue("icon", navigationSettings.Icon());
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