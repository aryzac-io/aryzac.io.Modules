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
    public class SidebarModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper
    {
        public const string SpecializationType = "Sidebar";
        public const string SpecializationTypeId = "7ad90260-1187-4e15-b6ba-313a2c215ff0";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public SidebarModel(IElement element, string requiredType = SpecializationType)
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

        public IList<StyleModel> Styles => _element.ChildElements
            .GetElementsOfType(StyleModel.SpecializationTypeId)
            .Select(x => new StyleModel(x))
            .ToList();

        public IList<NavigationSectionModel> Sections => _element.ChildElements
            .GetElementsOfType(NavigationSectionModel.SpecializationTypeId)
            .Select(x => new NavigationSectionModel(x))
            .ToList();

        public IList<LogoModel> Logos => _element.ChildElements
            .GetElementsOfType(LogoModel.SpecializationTypeId)
            .Select(x => new LogoModel(x))
            .ToList();

        public IList<NavigationItemModel> Items => _element.ChildElements
            .GetElementsOfType(NavigationItemModel.SpecializationTypeId)
            .Select(x => new NavigationItemModel(x))
            .ToList();

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(SidebarModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SidebarModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class SidebarModelExtensions
    {

        public static bool IsSidebarModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == SidebarModel.SpecializationTypeId;
        }

        public static SidebarModel AsSidebarModel(this ICanBeReferencedType type)
        {
            return type.IsSidebarModel() ? new SidebarModel((IElement)type) : null;
        }
    }
}