using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using Aryzac.IO.Modules.Client.Api;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.Modelers.WebClient.Api;
using Intent.Modules.Common;
using Intent.Modules.Common.FileBuilders.DataFileBuilder;
using Intent.Modules.Common.Templates;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;
using static System.Collections.Specialized.BitVector32;
using static Aryzac.IO.Modules.Client.Api.CheckboxModelStereotypeExtensions;
using static Aryzac.IO.Modules.Client.Api.SectionModelStereotypeExtensions;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.ProjectItemTemplate.Partial", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Templates.Files.Components.ComponentI18n
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class ComponentI18nTemplate : IntentTemplateBase<ComponentModel>, IDataFileBuilderTemplate
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Aryzac.IO.Modules.Client.Files.Components.Component i18n";

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public ComponentI18nTemplate(IOutputTarget outputTarget, ComponentModel model) : base(TemplateId, outputTarget, model)
        {
            DataFile = new DataFile($"{Model.GetPath().ToKebabCase()}/{Model.Name.ToKebabCase()}.i18n")
                .WithYamlWriter()
                .WithRootObject(this, @object =>
                {
                    foreach (var locale in GetLocales()[0].Locales)
                    {
                        @object
                            .WithObject(locale.Name, localeObject =>
                            {
                                if (Model.View is not null)
                                {
                                    AddModelView(localeObject, Model.View, locale);
                                }
                                else
                                {
                                    AddPlaceholder(localeObject);
                                }
                            });
                    }
                });
        }

        private void AddModelView(IDataFileObjectValue yamlObject, ComponentViewModel model, LocaleModel locale)
        {
            foreach (var component in model.InternalElement.ChildElements)
            {
                // Handling Heading Model
                if (component.IsHeadingModel())
                {
                    HandleHeading(yamlObject, component.AsHeadingModel(), locale);
                }
                // Handling Section Model
                else if (component.IsSectionModel())
                {
                    HandleSection(yamlObject, component.AsSectionModel(), locale);
                }
                // Handling Table Model outside of Section
                else if (component.IsTableModel())
                {
                    HandleTable(yamlObject, component.AsTableModel(), locale);
                }
            }

            if (!model.InternalElement.ChildElements.Any())
            {
                AddPlaceholder(yamlObject);
            }
        }

        private static void HandleTable(IDataFileObjectValue yamlObject, TableModel model, LocaleModel locale)
        {
            yamlObject.WithObject($"table-{model.Name.ToPascalCase().ToCamelCase()}", tableObject =>
            {
                foreach (var column in model.Columns)
                {
                    tableObject.WithValue(column.Name.ToPascalCase().ToCamelCase(), column.Name);
                }

                if (model.Actions is not null)
                {
                    HandleActions(tableObject, model.Actions, locale);
                }

                if (model.Columns.Count == 0 && model.Actions is null)
                {
                    AddPlaceholder(tableObject);
                }
            });
        }

        private static void HandleSection(IDataFileObjectValue yamlObject, SectionModel model, LocaleModel locale)
        {
            var sectionSettings = model.GetSectionSettingss().FirstOrDefault(s => s.Locale().Name == locale.Name);

            yamlObject.WithObject($"section-{model.Name.ToPascalCase().ToCamelCase()}", sectionObject =>
            {
                // Set title and description, use defaults if not available
                sectionObject.WithValue("title", sectionSettings?.Title() ?? model.Name ?? "''");
                sectionObject.WithValue("description", sectionSettings?.Description() ?? "''");

                foreach (var component in model.InternalElement.ChildElements)
                {
                    // Handling Textbox Model
                    if (component.IsTextboxModel())
                    {
                        HandleTextbox(sectionObject, component.AsTextboxModel(), locale);
                    }
                    // Handling TextArea Model
                    else if (component.IsTextAreaModel())
                    {
                        HandleTextArea(sectionObject, component.AsTextAreaModel(), locale);
                    }
                    // Handling Checkbox Model
                    else if (component.IsCheckboxModel())
                    {
                        HandleCheckbox(sectionObject, component.AsCheckboxModel(), locale);
                    }
                    // Handling Label Model
                    else if (component.IsLabelModel())
                    {
                        HandleLabel(sectionObject, component.AsLabelModel(), locale);
                    }
                    // Handling RadioButton Model
                    else if (component.IsRadioButtonModel())
                    {
                        HandleRadioButton(sectionObject, component.AsRadioButtonModel(), locale);
                    }
                    // Handling Select Model
                    else if (component.IsSelectModel())
                    {
                        HandleSelect(sectionObject, component.AsSelectModel(), locale);
                    }
                    // Handling Table Model
                    else if (component.IsTableModel())
                    {
                        HandleTable(sectionObject, component.AsTableModel(), locale);
                    }
                    // Handling Actions Model
                    else if (component.IsActionsModel())
                    {
                        HandleActions(sectionObject, component.AsActionsModel(), locale);
                    }
                }
            });
        }

        private static void HandleActions(IDataFileObjectValue yamlObject, ActionsModel model, LocaleModel locale)
        {
            yamlObject.WithObject("actions", actionsObject =>
            {
                foreach (var action in model.Actions)
                {
                    HandleAction(actionsObject, action, locale);
                }

                if (model.Actions.Count == 0)
                {
                    AddPlaceholder(actionsObject);
                }
            });
        }

        private static void HandleAction(IDataFileObjectValue yamlObject, ActionModel model, LocaleModel locale)
        {
            var actionSettings = model.GetActionSettingss().FirstOrDefault(s => s.Locale().Name == locale.Name);

            yamlObject.WithObject($"action-{model.Name.ToPascalCase().ToCamelCase()}", actionObject =>
            {
                // Set label, use control name as default if no specific setting is found
                actionObject.WithValue("label", actionSettings?.Label() ?? model.Name);
                if (actionSettings?.Icon() is not null)
                    actionObject.WithValue("icon", actionSettings.Icon());
            });
        }

        private static void HandleSelect(IDataFileObjectValue yamlObject, SelectModel model, LocaleModel locale)
        {
            var selectSettings = model.GetSelectSettingss().FirstOrDefault(s => s.Locale().Name == locale.Name);

            yamlObject.WithObject($"select-{model.Name.ToPascalCase().ToCamelCase()}", selectObject =>
            {
                // Set label, use control name as default if no specific setting is found
                selectObject.WithValue("label", selectSettings?.Label() ?? model.Name);
            });
        }

        private static void HandleRadioButton(IDataFileObjectValue yamlObject, RadioButtonModel model, LocaleModel locale)
        {
            var radioButtonSettings = model.GetRadioButtonSettingss().FirstOrDefault(s => s.Locale().Name == locale.Name);

            yamlObject.WithObject($"radio-{model.Name.ToPascalCase().ToCamelCase()}", radioButtonObject =>
            {
                // Set label, use control name as default if no specific setting is found
                radioButtonObject.WithValue("label", radioButtonSettings?.Label() ?? model.Name);
            });
        }

        private static void HandleLabel(IDataFileObjectValue yamlObject, LabelModel model, LocaleModel locale)
        {
            var labelSettings = model.GetLabelSettingss().FirstOrDefault(s => s.Locale().Name == locale.Name);

            yamlObject.WithObject($"label-{model.Name.ToPascalCase().ToCamelCase()}", labelObject =>
            {
                // Set label, use control name as default if no specific setting is found
                labelObject.WithValue("label", labelSettings?.Label() ?? model.Name);
            });
        }

        private static void HandleCheckbox(IDataFileObjectValue yamlObject, CheckboxModel model, LocaleModel locale)
        {
            var checkboxSettings = model.GetCheckboxSettingss().FirstOrDefault(s => s.Locale().Name == locale.Name);

            yamlObject.WithObject($"checkbox-{model.Name.ToPascalCase().ToCamelCase()}", checkboxObject =>
            {
                // Set label and description, use defaults if no specific setting is found
                checkboxObject.WithValue("label", checkboxSettings?.Label() ?? model.Name);
                checkboxObject.WithValue("description", checkboxSettings?.Description() ?? "''");
            });
        }

        private static void HandleTextArea(IDataFileObjectValue yamlObject, TextAreaModel model, LocaleModel locale)
        {
            var textareaSettings = model.GetTextAreaSettingss().FirstOrDefault(s => s.Locale().Name == locale.Name);

            yamlObject.WithObject($"text-area-{model.Name.ToPascalCase().ToCamelCase()}", textAreaObject =>
            {
                // Set label, use control name as default if no specific setting is found
                textAreaObject.WithValue("label", textareaSettings?.Label() ?? model.Name);
            });
        }

        private static void HandleTextbox(IDataFileObjectValue yamlObject, TextboxModel model, LocaleModel locale)
        {
            var textboxSettings = model.GetTextboxSettingss().FirstOrDefault(s => s.Locale().Name == locale.Name);

            yamlObject.WithObject($"textbox-{model.Name.ToPascalCase().ToCamelCase()}", textboxObject =>
            {
                textboxObject.WithValue("label", textboxSettings?.Label() ?? model.Name);
            });
        }

        private void HandleHeading(IDataFileObjectValue yamlObject, HeadingModel model, LocaleModel locale)
        {
            var headingSettings = model.GetHeadingSettingss().FirstOrDefault(s => s.Locale().Name == locale.Name);

            yamlObject.WithObject($"heading-{model.Name.ToPascalCase().ToCamelCase()}", headingObject =>
            {
                headingObject.WithValue("title", headingSettings?.Title() ?? model.Name);

                headingObject.WithObject("attributes", attributesObject =>
                {
                    foreach (var control in model.InternalElement.ChildElements.Where(m => m.IsHeadingAttributeModel()))
                    {
                        HandleHeadingAttribute(attributesObject, control.AsHeadingAttributeModel(), locale);
                    }

                    if (!model.InternalElement.ChildElements.Any(m => m.IsHeadingAttributeModel()))
                    {
                        AddPlaceholder(attributesObject);
                    }
                });

                foreach (var control in model.InternalElement.ChildElements.Where(m => m.IsActionsModel()))
                {
                    HandleActions(headingObject, control.AsActionsModel(), locale);
                }
            });
        }

        private void HandleHeadingAttribute(IDataFileObjectValue yamlObject, HeadingAttributeModel model, LocaleModel locale)
        {
            var headingAttributeSettings = model.GetAttributeSettingss().FirstOrDefault(s => s.Locale().Name == locale.Name);

            yamlObject.WithObject($"attribute-{model.Name.ToPascalCase().ToCamelCase()}", attributeObject =>
            {
                attributeObject.WithValue("label", headingAttributeSettings?.Label() ?? model.Name);
                if (headingAttributeSettings?.Icon() is not null)
                {
                    attributeObject.WithValue("icon", headingAttributeSettings?.Icon());
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