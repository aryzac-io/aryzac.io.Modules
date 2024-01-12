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
    public class SidebarNavigationSectionModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper
    {
        public const string SpecializationType = "Sidebar Navigation Section";
        public const string SpecializationTypeId = "3b2026bf-7e0e-47d3-aaa7-3fccb5739990";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public SidebarNavigationSectionModel(IElement element, string requiredType = SpecializationType)
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

        public IList<NavigationItemModel> Items => _element.ChildElements
            .GetElementsOfType(NavigationItemModel.SpecializationTypeId)
            .Select(x => new NavigationItemModel(x))
            .ToList();

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(SidebarNavigationSectionModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SidebarNavigationSectionModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class SidebarNavigationSectionModelExtensions
    {

        public static bool IsSidebarNavigationSectionModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == SidebarNavigationSectionModel.SpecializationTypeId;
        }

        public static SidebarNavigationSectionModel AsSidebarNavigationSectionModel(this ICanBeReferencedType type)
        {
            return type.IsSidebarNavigationSectionModel() ? new SidebarNavigationSectionModel((IElement)type) : null;
        }
    }
}