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
    public class CssStyleModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper
    {
        public const string SpecializationType = "Css Style";
        public const string SpecializationTypeId = "e02b68fc-516c-4e3e-a664-abbccb1686c3";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public CssStyleModel(IElement element, string requiredType = SpecializationType)
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

        public IList<CssPropertyModel> CssProperties => _element.ChildElements
            .GetElementsOfType(CssPropertyModel.SpecializationTypeId)
            .Select(x => new CssPropertyModel(x))
            .ToList();

        public IList<CssStyleModel> CssStyles => _element.ChildElements
            .GetElementsOfType(CssStyleModel.SpecializationTypeId)
            .Select(x => new CssStyleModel(x))
            .ToList();

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(CssStyleModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CssStyleModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class CssStyleModelExtensions
    {

        public static bool IsCssStyleModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == CssStyleModel.SpecializationTypeId;
        }

        public static CssStyleModel AsCssStyleModel(this ICanBeReferencedType type)
        {
            return type.IsCssStyleModel() ? new CssStyleModel((IElement)type) : null;
        }
    }
}