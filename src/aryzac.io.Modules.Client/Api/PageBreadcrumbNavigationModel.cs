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
    public class PageBreadcrumbNavigationModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper
    {
        public const string SpecializationType = "Page Breadcrumb Navigation";
        public const string SpecializationTypeId = "17381d4f-8bd9-4b00-9235-9243a3232c6a";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public PageBreadcrumbNavigationModel(IElement element, string requiredType = SpecializationType)
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

        public InheritedPageBreadcrumbModel Inherited => _element.ChildElements
            .GetElementsOfType(InheritedPageBreadcrumbModel.SpecializationTypeId)
            .Select(x => new InheritedPageBreadcrumbModel(x))
            .SingleOrDefault();

        public IList<NavigationItemModel> Items => _element.ChildElements
            .GetElementsOfType(NavigationItemModel.SpecializationTypeId)
            .Select(x => new NavigationItemModel(x))
            .ToList();

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(PageBreadcrumbNavigationModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PageBreadcrumbNavigationModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class PageBreadcrumbNavigationModelExtensions
    {

        public static bool IsPageBreadcrumbNavigationModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == PageBreadcrumbNavigationModel.SpecializationTypeId;
        }

        public static PageBreadcrumbNavigationModel AsPageBreadcrumbNavigationModel(this ICanBeReferencedType type)
        {
            return type.IsPageBreadcrumbNavigationModel() ? new PageBreadcrumbNavigationModel((IElement)type) : null;
        }
    }
}