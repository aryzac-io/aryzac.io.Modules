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
    public class LayoutModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper
    {
        public const string SpecializationType = "Layout";
        public const string SpecializationTypeId = "eb6cb3df-6d5a-469b-8919-ab659187874f";
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

        public TopMenuModel TopMenu => _element.ChildElements
            .GetElementsOfType(TopMenuModel.SpecializationTypeId)
            .Select(x => new TopMenuModel(x))
            .SingleOrDefault();

        public SidebarModel Sidebar => _element.ChildElements
            .GetElementsOfType(SidebarModel.SpecializationTypeId)
            .Select(x => new SidebarModel(x))
            .SingleOrDefault();

        public FooterModel Footer => _element.ChildElements
            .GetElementsOfType(FooterModel.SpecializationTypeId)
            .Select(x => new FooterModel(x))
            .SingleOrDefault();

        public IList<LayoutSlotModel> LayoutSlots => _element.ChildElements
            .GetElementsOfType(LayoutSlotModel.SpecializationTypeId)
            .Select(x => new LayoutSlotModel(x))
            .ToList();

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