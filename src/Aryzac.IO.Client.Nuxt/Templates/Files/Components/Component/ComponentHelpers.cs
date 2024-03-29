﻿using Aryzac.IO.Modules.Client.Api;
using Intent.Metadata.Models;
using Intent.Modelers.Types.ServiceProxies.Api;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aryzac.IO.Client.Nuxt.Templates.Files.Components.Component
{
    public class ComponentHelpers
    {
        private readonly ComponentModel Model;

        public ComponentHelpers(ComponentModel componentModel)
        {
            this.Model = componentModel;
        }

        public List<ComponentQueryModel> Queries => Model.InternalElement.ChildElements
            .GetElementsOfType(ComponentQueryModel.SpecializationTypeId, true)
            .Select(x => new ComponentQueryModel(x))
            .ToList();

        public List<ComponentCommandModel> Commands => Model.InternalElement.ChildElements
            .GetElementsOfType(ComponentCommandModel.SpecializationTypeId, true)
            .Select(x => new ComponentCommandModel(x))
            .ToList();

        public List<ServiceProxyModel> CommandsAndQueries
        {
            get
            {
                var commands = Model.InternalElement.ChildElements
                    .GetElementsOfType(ComponentCommandModel.SpecializationTypeId, true)
                    .Select(x => new ComponentCommandModel(x));

                var queries = Model.InternalElement.ChildElements
                    .GetElementsOfType(ComponentQueryModel.SpecializationTypeId, true)
                    .Select(x => new ComponentQueryModel(x));

                var response = new List<ServiceProxyModel>();
                if (commands is not null)
                    response.AddRange(commands.Select(m => m.Mapping.Element.AsOperationModel().ParentService));
                if (queries is not null)
                    response.AddRange(queries.Select(m => m.Mapping.Element.AsOperationModel().ParentService));

                return response.Distinct().ToList();
            }
        }

        public string GetMappedColumnFieldName(ColumnModel column)
        {
            foreach (var mapping in column.InternalElement.ParentElement.Mappings)
            {
                foreach (var mappedEnd in mapping.MappedEnds)
                {
                    if (mappedEnd.TargetElement.Id == column.Id)
                    {
                        return mappedEnd.SourceElement.Name.ToCamelCase();
                    }
                }
            }

            return column.Name.ToCamelCase();
        }

        public string GetMappedPropertyName(ComponentModelFieldModel field)
        {
            foreach (var mapping in field.InternalElement.ParentElement.Mappings)
            {
                foreach (var mappedEnd in mapping.MappedEnds)
                {
                    if (mappedEnd.TargetElement.Id == field.Id)
                    {
                        return mappedEnd.SourceElement.Name.ToCamelCase();
                    }
                }
            }

            return field.Name.ToCamelCase();
        }

        public string GetMappedTextboxName(TextboxModel field)
        {
            foreach (var mapping in field.InternalElement.ParentElement.ParentElement.Mappings)
            {
                foreach (var mappedEnd in mapping.MappedEnds)
                {
                    if (mappedEnd.TargetElement.Id == field.Id)
                    {
                        return mappedEnd.SourceElement.Name.ToCamelCase();
                    }
                }
            }

            return field.Name.ToCamelCase();
        }

        public string GetMappedTextAreaName(TextAreaModel field)
        {
            foreach (var mapping in field.InternalElement.ParentElement.ParentElement.Mappings)
            {
                foreach (var mappedEnd in mapping.MappedEnds)
                {
                    if (mappedEnd.TargetElement.Id == field.Id)
                    {
                        return mappedEnd.SourceElement.Name.ToCamelCase();
                    }
                }
            }

            return field.Name.ToCamelCase();
        }

        public string GetMappedCheckboxName(CheckboxModel field)
        {
            foreach (var mapping in field.InternalElement.ParentElement.ParentElement.Mappings)
            {
                foreach (var mappedEnd in mapping.MappedEnds)
                {
                    if (mappedEnd.TargetElement.Id == field.Id)
                    {
                        return mappedEnd.SourceElement.Name.ToCamelCase();
                    }
                }
            }

            return field.Name.ToCamelCase();
        }

        public string GetMappedLabelName(LabelModel field)
        {
            foreach (var mapping in field.InternalElement.ParentElement.ParentElement.Mappings)
            {
                foreach (var mappedEnd in mapping.MappedEnds)
                {
                    if (mappedEnd.TargetElement.Id == field.Id)
                    {
                        return mappedEnd.SourceElement.Name.ToCamelCase();
                    }
                }
            }

            return field.Name.ToCamelCase();
        }

        public string GetMappedRadioButtonName(RadioButtonModel field)
        {
            foreach (var mapping in field.InternalElement.ParentElement.ParentElement.Mappings)
            {
                foreach (var mappedEnd in mapping.MappedEnds)
                {
                    if (mappedEnd.TargetElement.Id == field.Id)
                    {
                        return mappedEnd.SourceElement.Name.ToCamelCase();
                    }
                }
            }

            return field.Name.ToCamelCase();
        }

        public string GetMappedSelectName(SelectModel field)
        {
            foreach (var mapping in field.InternalElement.ParentElement.ParentElement.Mappings)
            {
                foreach (var mappedEnd in mapping.MappedEnds)
                {
                    if (mappedEnd.TargetElement.Id == field.Id)
                    {
                        return mappedEnd.SourceElement.Name.ToCamelCase();
                    }
                }
            }

            return field.Name.ToCamelCase();
        }

        public string GetMappedModelName(ComponentModelFieldModel field)
        {
            foreach (var mapping in field.InternalElement.ParentElement.ParentElement.Mappings)
            {
                foreach (var mappedEnd in mapping.MappedEnds)
                {
                    if (mappedEnd.TargetElement.Id == field.Id)
                    {
                        return mappedEnd.SourceElement.Name.ToCamelCase();
                    }
                }
            }

            return field.Name.ToCamelCase();
        }

        public string GetMappedName(IElement field, ComponentCommandModel command)
        {
            foreach (var mapping in command.InternalElement.Mappings)
            {
                foreach (var mappedEnd in mapping.MappedEnds)
                {
                    if (mappedEnd.TargetElement.Id == field.Id)
                    {
                        return mappedEnd.SourceElement.Name.ToCamelCase();
                    }
                }
            }

            return field.Name.ToCamelCase();
        }
    }
}
