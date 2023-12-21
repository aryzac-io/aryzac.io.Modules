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
    public class FormDefinitionFieldModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper, IHasTypeReference
    {
        public const string SpecializationType = "Form Definition Field";
        public const string SpecializationTypeId = "4ece4d5c-c89b-43ee-8aec-b474410623c6";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public FormDefinitionFieldModel(IElement element, string requiredType = SpecializationType)
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

        public ITypeReference TypeReference => _element.TypeReference;


        public bool IsMapped => _element.IsMapped;

        public IElementMapping Mapping => _element.MappedElement;

        public IElement InternalElement => _element;

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(FormDefinitionFieldModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((FormDefinitionFieldModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class FormDefinitionFieldModelExtensions
    {

        public static bool IsFormDefinitionFieldModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == FormDefinitionFieldModel.SpecializationTypeId;
        }

        public static FormDefinitionFieldModel AsFormDefinitionFieldModel(this ICanBeReferencedType type)
        {
            return type.IsFormDefinitionFieldModel() ? new FormDefinitionFieldModel((IElement)type) : null;
        }

        public static bool HasMapFromModelMapping(this FormDefinitionFieldModel type)
        {
            return type.Mapping?.MappingSettingsId == "71349500-1578-4d10-a04e-7c07ac77f1d2";
        }

        public static IElementMapping GetMapFromModelMapping(this FormDefinitionFieldModel type)
        {
            return type.HasMapFromModelMapping() ? type.Mapping : null;
        }
    }
}