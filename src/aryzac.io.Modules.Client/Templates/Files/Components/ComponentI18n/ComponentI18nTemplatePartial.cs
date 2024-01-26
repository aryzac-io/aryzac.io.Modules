using System;
using System.Collections.Generic;
using System.Linq;
using Aryzac.IO.Modules.Client.Api;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.Modules.Common.FileBuilders.DataFileBuilder;
using Intent.Modules.Common.Templates;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

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
                    @object
                        .WithObject("en", en =>
                        {
                            if (Model.View is not null)
                            {
                                foreach (var component in Model.View.InternalElement.ChildElements)
                                {
                                    // Handling Heading Model
                                    if (component.IsHeadingModel())
                                    {
                                        Model.View.Heading.TryGetHeadingSettings(out var headingSettings);
                                        en.WithObject(Model.View.Heading.Name.ToPascalCase().ToCamelCase(), heading =>
                                        {
                                            heading.WithValue("title", headingSettings.Title() ?? Model.View.Heading.Name);

                                            if (Model.View.Heading.Attributes.Any())
                                            {
                                                heading.WithObject("attributes", attributes =>
                                                {
                                                    foreach (var attribute in Model.View.Heading.Attributes)
                                                    {
                                                        attributes.WithValue(attribute.Name.ToCamelCase() + "Label", attribute.Name ?? "''");
                                                    }
                                                });
                                            }
                                        });
                                    }
                                    // Handling Section Model
                                    else if (component.IsSectionModel())
                                    {
                                        var section = component.AsSectionModel();
                                        section.TryGetSectionSettings(out var sectionSettings);
                                        en.WithObject(component.Name.ToPascalCase().ToCamelCase(), sectionObj =>
                                        {
                                            sectionObj.WithValue("title", sectionSettings.Title() ?? component.Name);
                                            sectionObj.WithValue("description", sectionSettings.Description() ?? "''");

                                            foreach (var control in section.InternalElement.ChildElements)
                                            {
                                                // Handling Textbox Model
                                                if (control.IsTextboxModel())
                                                {
                                                    var textbox = control.AsTextboxModel();
                                                    textbox.TryGetTextboxSettings(out var textboxSettings);
                                                    sectionObj.WithObject(control.Name.ToPascalCase().ToCamelCase(), textboxObj =>
                                                    {
                                                        textboxObj.WithValue("label", textboxSettings.Label() ?? control.Name);
                                                    });
                                                }
                                                // Handling TextArea Model
                                                else if (control.IsTextAreaModel())
                                                {
                                                    var textarea = control.AsTextAreaModel();
                                                    textarea.TryGetTextAreaSettings(out var textareaSettings);
                                                    sectionObj.WithObject(control.Name.ToPascalCase().ToCamelCase(), textareaObj =>
                                                    {
                                                        textareaObj.WithValue("label", textareaSettings.Label() ?? control.Name);
                                                    });
                                                }
                                                // Handling Checkbox Model
                                                else if (control.IsCheckboxModel())
                                                {
                                                    var checkbox = control.AsCheckboxModel();
                                                    checkbox.TryGetCheckboxSettings(out var checkboxSettings);
                                                    sectionObj.WithObject(control.Name.ToPascalCase().ToCamelCase(), checkboxObj =>
                                                    {
                                                        checkboxObj.WithValue("label", checkboxSettings.Label() ?? control.Name);
                                                        checkboxObj.WithValue("description", checkboxSettings.Description() ?? "''");
                                                    });
                                                }
                                                // Handling Label Model
                                                else if (control.IsLabelModel())
                                                {
                                                    var label = control.AsLabelModel();
                                                    label.TryGetLabelSettings(out var labelSettings);
                                                    sectionObj.WithObject(control.Name.ToPascalCase().ToCamelCase(), labelObj =>
                                                    {
                                                        labelObj.WithValue("label", labelSettings.Label() ?? control.Name);
                                                    });
                                                }
                                                // Handling RadioButton Model
                                                else if (control.IsRadioButtonModel())
                                                {
                                                    var radioButton = control.AsRadioButtonModel();
                                                    radioButton.TryGetRadioButtonSettings(out var radioButtonSettings);
                                                    sectionObj.WithObject(control.Name.ToPascalCase().ToCamelCase(), radioButtonObj =>
                                                    {
                                                        radioButtonObj.WithValue("label", radioButtonSettings.Label() ?? control.Name);
                                                    });
                                                }
                                                // Handling Select Model
                                                else if (control.IsSelectModel())
                                                {
                                                    var select = control.AsSelectModel();
                                                    select.TryGetSelectSettings(out var selectSettings);
                                                    sectionObj.WithObject(control.Name.ToPascalCase().ToCamelCase(), selectObj =>
                                                    {
                                                        selectObj.WithValue("label", selectSettings.Label() ?? control.Name);
                                                    });
                                                }
                                                // Handling Table Model
                                                else if (control.IsTableModel())
                                                {
                                                    var table = control.AsTableModel();
                                                    sectionObj.WithObject(control.Name.ToPascalCase().ToCamelCase(), tableObj =>
                                                    {
                                                        foreach (var column in table.Columns)
                                                        {
                                                            tableObj.WithValue(column.Name.ToCamelCase(), column.Name);
                                                        }
                                                    });
                                                }
                                                // Handling Actions Model
                                                else if (control.IsActionsModel())
                                                {
                                                    var actions = control.AsActionsModel();
                                                    sectionObj.WithObject("actions", actionsObj =>
                                                    {
                                                        foreach (var actionElement in actions.InternalElement.ChildElements)
                                                        {
                                                            var action = actionElement.AsActionModel();
                                                            action.TryGetActionSettings(out var actionSettings);
                                                            actionsObj.WithValue(action.Name.ToPascalCase().ToCamelCase(), actionSettings.Label() ?? action.Name);
                                                        }
                                                    });
                                                }
                                            }
                                        });
                                    }
                                    // Handling Table Model outside of Section
                                    else if (component.IsTableModel())
                                    {
                                        var table = component.AsTableModel();
                                        en.WithObject(component.Name.ToPascalCase().ToCamelCase(), tableObj =>
                                        {
                                            foreach (var column in table.Columns)
                                            {
                                                tableObj.WithValue(column.Name.ToCamelCase(), column.Name);
                                            }
                                        });
                                    }
                                }
                            }
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