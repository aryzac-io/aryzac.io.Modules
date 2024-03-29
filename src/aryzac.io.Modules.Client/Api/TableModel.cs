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
    public class TableModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper
    {
        public const string SpecializationType = "Table";
        public const string SpecializationTypeId = "dd36c8ad-0f9e-4a38-8478-8dce769e0054";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public TableModel(IElement element, string requiredType = SpecializationType)
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

        public ComponentQueryModel Query => _element.ChildElements
            .GetElementsOfType(ComponentQueryModel.SpecializationTypeId)
            .Select(x => new ComponentQueryModel(x))
            .SingleOrDefault();

        public IList<ColumnModel> Columns => _element.ChildElements
            .GetElementsOfType(ColumnModel.SpecializationTypeId)
            .Select(x => new ColumnModel(x))
            .ToList();

        public ActionsModel Actions => _element.ChildElements
            .GetElementsOfType(ActionsModel.SpecializationTypeId)
            .Select(x => new ActionsModel(x))
            .SingleOrDefault();

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(TableModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TableModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class TableModelExtensions
    {

        public static bool IsTableModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == TableModel.SpecializationTypeId;
        }

        public static TableModel AsTableModel(this ICanBeReferencedType type)
        {
            return type.IsTableModel() ? new TableModel((IElement)type) : null;
        }
    }
}