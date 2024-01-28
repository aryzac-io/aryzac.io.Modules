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
            DataFile = new DataFile($"{Model.GetPath()}/{Model.Name}.i18n")
                .WithYamlWriter()
                .WithRootObject(this, @object =>
                {
                    foreach (var locale in GetLocales()[0].Locales)
                    {
                        @object
                            .WithObject(locale.Name, l =>
                            {
                                AddModelView(l, locale);
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

        private void AddModelView(IDataFileObjectValue en, LocaleModel locale)
        {
            if (Model.View is not null)
            {
                foreach (var component in Model.View.InternalElement.ChildElements)
                {
                    // Handling Heading Model
                    if (component.IsHeadingModel())
                    {
                        HandleHeading(en, component, locale);
                    }
                    // Handling Section Model
                    else if (component.IsSectionModel())
                    {
                        HandleSection(en, component, locale);
                    }
                    // Handling Table Model outside of Section
                    else if (component.IsTableModel())
                    {
                        HandleTable(en, component, locale);
                    }
                }
            }
        }

        private static void HandleTable(IDataFileObjectValue en, IElement component, LocaleModel locale)
        {
            var table = component.AsTableModel();
            en.WithObject(component.Name.ToPascalCase().ToCamelCase(), tableObj =>
            {
                foreach (var column in table.Columns)
                {
                    tableObj.WithValue(column.Name.ToPascalCase().ToCamelCase(), column.Name);
                }

                if (table.Actions is not null)
                {
                    tableObj.WithObject("actions", actions =>
                    {
                        foreach (var action in table.Actions.Actions)
                        {
                            action.TryGetActionSettings(out var actionSettings);
                            actions.WithObject(action.Name.ToPascalCase().ToCamelCase(), actionObj =>
                            {
                                actionObj.WithValue("label", actionSettings.Label() ?? action.Name);
                                if (actionSettings.Icon() is not null)
                                    actionObj.WithValue("icon", actionSettings.Icon());
                            });
                        }
                    });
                }
            });
        }

        private static void HandleSection(IDataFileObjectValue en, IElement component, LocaleModel locale)
        {
            var section = component.AsSectionModel();
            var sectionSettings = section.GetSectionSettingss().FirstOrDefault(s => s.Locale().Name == locale.Name);

            en.WithObject(component.Name.ToPascalCase().ToCamelCase(), sectionObj =>
            {
                // Set title and description, use defaults if not available
                sectionObj.WithValue("title", sectionSettings?.Title() ?? component.Name ?? "''");
                sectionObj.WithValue("description", sectionSettings?.Description() ?? "''");

                foreach (var control in section.InternalElement.ChildElements)
                {
                    // Handling Textbox Model
                    if (control.IsTextboxModel())
                    {
                        HandleTextbox(sectionObj, control, locale);
                    }
                    // Handling TextArea Model
                    else if (control.IsTextAreaModel())
                    {
                        HandleTextArea(sectionObj, control, locale);
                    }
                    // Handling Checkbox Model
                    else if (control.IsCheckboxModel())
                    {
                        HandleCheckbox(sectionObj, control, locale);
                    }
                    // Handling Label Model
                    else if (control.IsLabelModel())
                    {
                        HandleLabel(sectionObj, control, locale);
                    }
                    // Handling RadioButton Model
                    else if (control.IsRadioButtonModel())
                    {
                        HandleRadioButton(sectionObj, control, locale);
                    }
                    // Handling Select Model
                    else if (control.IsSelectModel())
                    {
                        HandleSelect(sectionObj, control, locale);
                    }
                    // Handling Table Model
                    else if (control.IsTableModel())
                    {
                        HandleTable(sectionObj, control, locale);
                    }
                    // Handling Actions Model
                    else if (control.IsActionsModel())
                    {
                        HandleActions(sectionObj, control, locale);
                    }
                }
            });
        }

        private static void HandleActions(IDataFileObjectValue sectionObj, IElement control, LocaleModel locale)
        {
            var actions = control.AsActionsModel();
            sectionObj.WithObject("actions", actionsObj =>
            {
                foreach (var action in actions.InternalElement.ChildElements)
                {
                    HandleAction(actionsObj, action, locale);
                }
            });
        }

        private static void HandleAction(IDataFileObjectValue sectionObj, IElement control, LocaleModel locale)
        {
            var action = control.AsActionModel();
            var actionSettings = action.GetActionSettingss().FirstOrDefault(s => s.Locale().Name == locale.Name);

            sectionObj.WithObject(control.Name.ToPascalCase().ToCamelCase(), selectObj =>
            {
                // Set label, use control name as default if no specific setting is found
                selectObj.WithValue("label", actionSettings?.Label() ?? control.Name);
            });
        }

        private static void HandleSelect(IDataFileObjectValue sectionObj, IElement control, LocaleModel locale)
        {
            var select = control.AsSelectModel();
            var selectSettings = select.GetSelectSettingss().FirstOrDefault(s => s.Locale().Name == locale.Name);

            sectionObj.WithObject(control.Name.ToPascalCase().ToCamelCase(), selectObj =>
            {
                // Set label, use control name as default if no specific setting is found
                selectObj.WithValue("label", selectSettings?.Label() ?? control.Name);
            });
        }

        private static void HandleRadioButton(IDataFileObjectValue sectionObj, IElement control, LocaleModel locale)
        {
            var radioButton = control.AsRadioButtonModel();
            var radioButtonSettings = radioButton.GetRadioButtonSettingss().FirstOrDefault(s => s.Locale().Name == locale.Name);

            sectionObj.WithObject(control.Name.ToPascalCase().ToCamelCase(), radioButtonObj =>
            {
                // Set label, use control name as default if no specific setting is found
                radioButtonObj.WithValue("label", radioButtonSettings?.Label() ?? control.Name);
            });
        }

        private static void HandleLabel(IDataFileObjectValue sectionObj, IElement control, LocaleModel locale)
        {
            var label = control.AsLabelModel();
            var labelSettings = label.GetLabelSettingss().FirstOrDefault(s => s.Locale().Name == locale.Name);

            sectionObj.WithObject(control.Name.ToPascalCase().ToCamelCase(), labelObj =>
            {
                // Set label, use control name as default if no specific setting is found
                labelObj.WithValue("label", labelSettings?.Label() ?? control.Name);
            });
        }

        private static void HandleCheckbox(IDataFileObjectValue sectionObj, IElement control, LocaleModel locale)
        {
            var checkbox = control.AsCheckboxModel();
            var checkboxSettings = checkbox.GetCheckboxSettingss().FirstOrDefault(s => s.Locale().Name == locale.Name);

            sectionObj.WithObject(control.Name.ToPascalCase().ToCamelCase(), checkboxObj =>
            {
                // Set label and description, use defaults if no specific setting is found
                checkboxObj.WithValue("label", checkboxSettings?.Label() ?? control.Name);
                checkboxObj.WithValue("description", checkboxSettings?.Description() ?? "''");
            });
        }

        private static void HandleTextArea(IDataFileObjectValue sectionObj, IElement control, LocaleModel locale)
        {
            var textarea = control.AsTextAreaModel();
            var textareaSettings = textarea.GetTextAreaSettingss().FirstOrDefault(s => s.Locale().Name == locale.Name);

            sectionObj.WithObject(control.Name.ToPascalCase().ToCamelCase(), textareaObj =>
            {
                // Set label, use control name as default if no specific setting is found
                textareaObj.WithValue("label", textareaSettings?.Label() ?? control.Name);
            });
        }

        private static void HandleTextbox(IDataFileObjectValue sectionObj, IElement control, LocaleModel locale)
        {
            var textbox = control.AsTextboxModel();
            var textboxSettings = textbox.GetTextboxSettingss().FirstOrDefault(s => s.Locale().Name == locale.Name);

            sectionObj.WithObject(control.Name.ToPascalCase().ToCamelCase(), textboxObj =>
            {
                textboxObj.WithValue("label", textboxSettings?.Label() ?? control.Name);
            });
        }

        private void HandleHeading(IDataFileObjectValue en, IElement control, LocaleModel locale)
        {
            var heading = control.AsHeadingModel();
            var headingSettings = heading.GetHeadingSettingss().FirstOrDefault(s => s.Locale().Name == locale.Name);

            en.WithObject(control.Name.ToPascalCase().ToCamelCase(), headingObj =>
            {
                headingObj.WithValue("title", headingSettings?.Title() ?? control.Name);

                headingObj.WithObject("attributes", attributeObj =>
                {
                    foreach (var control in heading.InternalElement.ChildElements.Where(m => m.IsHeadingAttributeModel()))
                    {
                        HandleHeadingAttribute(attributeObj, control, locale);
                    }
                });

                foreach (var control in heading.InternalElement.ChildElements.Where(m => m.IsActionsModel()))
                {
                    HandleActions(headingObj, control, locale);
                }
            });
        }

        private void HandleHeadingAttribute(IDataFileObjectValue en, IElement control, LocaleModel locale)
        {
            var headingAttribute = control.AsHeadingAttributeModel();
            var headingAttributeSettings = headingAttribute.GetAttributeSettingss().FirstOrDefault(s => s.Locale().Name == locale.Name);

            en.WithObject(control.Name.ToPascalCase().ToCamelCase(), textboxObj =>
            {
                textboxObj.WithValue("label", headingAttributeSettings?.Label() ?? control.Name);
                if (headingAttributeSettings?.Icon() is not null)
                {
                    textboxObj.WithValue("icon", headingAttributeSettings?.Icon());
                }
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