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
    public class ShadowModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper
    {
        public const string SpecializationType = "Shadow";
        public const string SpecializationTypeId = "a9758e3e-6a68-4b04-be98-06ced343ff37";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public ShadowModel(IElement element, string requiredType = SpecializationType)
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

        public IElement InternalElement => _element;

        public ColorModel Color => _element.ChildElements
            .GetElementsOfType(ColorModel.SpecializationTypeId)
            .Select(x => new ColorModel(x))
            .SingleOrDefault();

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(ShadowModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ShadowModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class ShadowModelExtensions
    {

        public static bool IsShadowModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == ShadowModel.SpecializationTypeId;
        }

        public static ShadowModel AsShadowModel(this ICanBeReferencedType type)
        {
            return type.IsShadowModel() ? new ShadowModel((IElement)type) : null;
        }
    }
}