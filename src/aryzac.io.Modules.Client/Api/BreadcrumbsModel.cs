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
    public class BreadcrumbsModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper
    {
        public const string SpecializationType = "Breadcrumbs";
        public const string SpecializationTypeId = "d33b7909-0ff3-49ea-a9c0-8bc50f29e34d";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public BreadcrumbsModel(IElement element, string requiredType = SpecializationType)
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

        public IList<BreadcrumbModel> Breadcrumbs => _element.ChildElements
            .GetElementsOfType(BreadcrumbModel.SpecializationTypeId)
            .Select(x => new BreadcrumbModel(x))
            .ToList();

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(BreadcrumbsModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BreadcrumbsModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class BreadcrumbsModelExtensions
    {

        public static bool IsBreadcrumbsModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == BreadcrumbsModel.SpecializationTypeId;
        }

        public static BreadcrumbsModel AsBreadcrumbsModel(this ICanBeReferencedType type)
        {
            return type.IsBreadcrumbsModel() ? new BreadcrumbsModel((IElement)type) : null;
        }
    }
}