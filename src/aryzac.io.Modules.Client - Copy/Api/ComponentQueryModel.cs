using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modelers.Services.Api;
using Intent.Modules.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiElementModel", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Api
{
    [IntentManaged(Mode.Fully, Signature = Mode.Fully)]
    public class ComponentQueryModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper
    {
        public const string SpecializationType = "Component Query";
        public const string SpecializationTypeId = "bfacaee7-4850-4353-bb99-6b52b81fc804";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public ComponentQueryModel(IElement element, string requiredType = SpecializationType)
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

        public bool Equals(ComponentQueryModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ComponentQueryModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class ComponentQueryModelExtensions
    {

        public static bool IsComponentQueryModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == ComponentQueryModel.SpecializationTypeId;
        }

        public static ComponentQueryModel AsComponentQueryModel(this ICanBeReferencedType type)
        {
            return type.IsComponentQueryModel() ? new ComponentQueryModel((IElement)type) : null;
        }

        public static bool HasQueryMappingMapping(this ComponentQueryModel type)
        {
            return type.Mapping?.MappingSettingsId == "6d2115a7-eb3d-437c-9b6b-22525284fe44";
        }

        public static IElementMapping GetQueryMappingMapping(this ComponentQueryModel type)
        {
            return type.HasQueryMappingMapping() ? type.Mapping : null;
        }
    }
}