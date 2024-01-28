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

namespace Aryzac.IO.Modules.Client.Templates.Files.Layouts.LayoutI18n
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class LayoutI18nTemplate : IntentTemplateBase<LayoutModel>, IDataFileBuilderTemplate
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Aryzac.IO.Modules.Client.Files.Layouts.Layout i18n";

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
                            .WithObject(locale.Name, l =>
                            {
                                AddModelTopNavigation(l, locale);
                                AddModelSidebarNavigation(l, locale);
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

        private void AddModelTopNavigation(IDataFileObjectValue en, LocaleModel locale)
        {
            if (Model.TopNavigation is not null)
            {
                en.WithObject("appbar", appbarObj =>
                {
                    appbarObj.WithObject("navigation", navigationObj =>
                    {
                        foreach (var child in Model.TopNavigation.InternalElement.ChildElements)
                        {
                            if (child.IsTopNavigationSectionModel())
                            {
                                foreach (var section in Model.TopNavigation.Sections)
                                {
                                    foreach (var item in section.Items)
                                    {
                                        item.TryGetNavigationItemSettings(out var navigationSettings);

                                        navigationObj.WithObject(item.Name.ToPascalCase().ToCamelCase(), itemObj =>
                                        {
                                            itemObj.WithValue("label", navigationSettings.Label() ?? item.Name);

                                            if (navigationSettings.Icon() != null)
                                            {
                                                itemObj.WithValue("icon", navigationSettings.Icon());
                                            }
                                        });
                                    }
                                }
                            }
                        }
                    });
                });
            }
        }

        private void AddModelSidebarNavigation(IDataFileObjectValue en, LocaleModel locale)
        {
            if (Model.SidebarNavigation is not null)
            {
                en.WithObject("sidebar", sidebarObj =>
                {
                    sidebarObj.WithObject("navigation", navigationObj =>
                    {
                        foreach (var section in Model.SidebarNavigation.Sections)
                        {
                            navigationObj.WithObject(section.Name.ToPascalCase().ToCamelCase(), sectionObj =>
                            {
                                foreach (var item in section.Items)
                                {
                                    item.TryGetNavigationItemSettings(out var navigationSettings);

                                    sectionObj.WithObject(item.Name.ToPascalCase().ToCamelCase(), itemObj =>
                                    {
                                        itemObj.WithValue("label", navigationSettings.Label() ?? item.Name);

                                        if (navigationSettings.Icon() != null)
                                        {
                                            itemObj.WithValue("icon", navigationSettings.Icon());
                                        }
                                    });
                                }
                            });
                        }
                    });
                });
            }
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
                            item.TryGetNavigationItemSettings(out var navigationSettings);

                            navigationObj.WithObject(item.Name.ToPascalCase().ToCamelCase(), itemObj =>
                            {
                                itemObj.WithValue("label", navigationSettings.Label() ?? item.Name);

                                if (navigationSettings.Icon() != null)
                                {
                                    itemObj.WithValue("icon", navigationSettings.Icon());
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