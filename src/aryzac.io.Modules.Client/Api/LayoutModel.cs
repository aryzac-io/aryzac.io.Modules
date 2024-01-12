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
    public class LayoutModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper
    {
        public const string SpecializationType = "Layout";
        public const string SpecializationTypeId = "256217fb-92b3-4b8f-9f50-7d33db1d4a7e";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public LayoutModel(IElement element, string requiredType = SpecializationType)
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

        public TopNavigationModel TopNavigation => _element.ChildElements
            .GetElementsOfType(TopNavigationModel.SpecializationTypeId)
            .Select(x => new TopNavigationModel(x))
            .SingleOrDefault();

        public SidebarNavigationModel SidebarNavigation => _element.ChildElements
            .GetElementsOfType(SidebarNavigationModel.SpecializationTypeId)
            .Select(x => new SidebarNavigationModel(x))
            .SingleOrDefault();

        public BreadcrumbNavigationModel BreadcrumbNavigation => _element.ChildElements
            .GetElementsOfType(BreadcrumbNavigationModel.SpecializationTypeId)
            .Select(x => new BreadcrumbNavigationModel(x))
            .SingleOrDefault();

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(LayoutModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((LayoutModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class LayoutModelExtensions
    {

        public static bool IsLayoutModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == LayoutModel.SpecializationTypeId;
        }

        public static LayoutModel AsLayoutModel(this ICanBeReferencedType type)
        {
            return type.IsLayoutModel() ? new LayoutModel((IElement)type) : null;
        }
    }
}