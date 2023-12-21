using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiElementModel", Version = "1.0")]

namespace Aryzac.Io.Modules.Client.Api
{
    [IntentManaged(Mode.Fully, Signature = Mode.Fully)]
    public class FormDefinitionModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper
    {
        public const string SpecializationType = "Form Definition";
        public const string SpecializationTypeId = "df0da0e1-b468-4868-8135-22caf8767eeb";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public FormDefinitionModel(IElement element, string requiredType = SpecializationType)
        {
            if (!requiredType.Equals(element.SpecializationType, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception($"Cannot create a '{GetType().Name}' from element with specialization type '{element.SpecializationType}'. Must be of type '{SpecializationType}'");
            }
            _element = element;
        }

        public string Id => _element.Id;

        public string Name => _element.Name;

        public string Comment => _element.Comment;

        public IEnumerable<IStereotype> Stereotypes => _element.Stereotypes;

        public bool IsMapped => _element.IsMapped;

        public IElementMapping Mapping => _element.MappedElement;

        public IElement InternalElement => _element;

        public IList<FormDefinitionFieldModel> Fields => _element.ChildElements
            .GetElementsOfType(FormDefinitionFieldModel.SpecializationTypeId)
            .Select(x => new FormDefinitionFieldModel(x))
            .ToList();

        public IList<ComponentSectionModel> ComponentSections => _element.ChildElements
            .GetElementsOfType(ComponentSectionModel.SpecializationTypeId)
            .Select(x => new ComponentSectionModel(x))
            .ToList();

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(FormDefinitionModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((FormDefinitionModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class FormDefinitionModelExtensions
    {

        public static bool IsFormDefinitionModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == FormDefinitionModel.SpecializationTypeId;
        }

        public static FormDefinitionModel AsFormDefinitionModel(this ICanBeReferencedType type)
        {
            return type.IsFormDefinitionModel() ? new FormDefinitionModel((IElement)type) : null;
        }

        public static bool HasMapFromDTOMapping(this FormDefinitionModel type)
        {
            return type.Mapping?.MappingSettingsId == "e14e2455-2bdd-4e46-ac60-123ef724f953";
        }

        public static IElementMapping GetMapFromDTOMapping(this FormDefinitionModel type)
        {
            return type.HasMapFromDTOMapping() ? type.Mapping : null;
        }

        public static bool HasMapFromModelMapping(this FormDefinitionModel type)
        {
            return type.Mapping?.MappingSettingsId == "939cf7e0-d31d-40b0-855f-fbb3bb8bc054";
        }

        public static IElementMapping GetMapFromModelMapping(this FormDefinitionModel type)
        {
            return type.HasMapFromModelMapping() ? type.Mapping : null;
        }
    }
}