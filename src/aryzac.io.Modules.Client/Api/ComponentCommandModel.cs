using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiElementModel", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Api
{
    [IntentManaged(Mode.Fully, Signature = Mode.Fully)]
    public class ComponentCommandModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper
    {
        public const string SpecializationType = "Component Command";
        public const string SpecializationTypeId = "52a388d5-ebcb-44d6-bbb7-8608597a06a8";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public ComponentCommandModel(IElement element, string requiredType = SpecializationType)
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

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(ComponentCommandModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ComponentCommandModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class ComponentCommandModelExtensions
    {

        public static bool IsComponentCommandModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == ComponentCommandModel.SpecializationTypeId;
        }

        public static ComponentCommandModel AsComponentCommandModel(this ICanBeReferencedType type)
        {
            return type.IsComponentCommandModel() ? new ComponentCommandModel((IElement)type) : null;
        }

        public static bool HasCommandMappingMapping(this ComponentCommandModel type)
        {
            return type.Mapping?.MappingSettingsId == "3eda3b99-cbdc-4218-95e8-fee082b6139e";
        }

        public static IElementMapping GetCommandMappingMapping(this ComponentCommandModel type)
        {
            return type.HasCommandMappingMapping() ? type.Mapping : null;
        }
    }
}