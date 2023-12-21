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
    public class ModelDefinitionModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper
    {
        public const string SpecializationType = "Model Definition";
        public const string SpecializationTypeId = "3b3aae7a-a51a-4352-a000-2b2bffb05dbf";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public ModelDefinitionModel(IElement element, string requiredType = SpecializationType)
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

        public IList<ModelDefinitionFieldModel> Fields => _element.ChildElements
            .GetElementsOfType(ModelDefinitionFieldModel.SpecializationTypeId)
            .Select(x => new ModelDefinitionFieldModel(x))
            .ToList();

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(ModelDefinitionModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ModelDefinitionModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class ModelDefinitionModelExtensions
    {

        public static bool IsModelDefinitionModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == ModelDefinitionModel.SpecializationTypeId;
        }

        public static ModelDefinitionModel AsModelDefinitionModel(this ICanBeReferencedType type)
        {
            return type.IsModelDefinitionModel() ? new ModelDefinitionModel((IElement)type) : null;
        }

        public static bool HasMapModelDefinitionMapping(this ModelDefinitionModel type)
        {
            return type.Mapping?.MappingSettingsId == "02a46260-ec24-425f-bb97-4b9ce84dc18a";
        }

        public static IElementMapping GetMapModelDefinitionMapping(this ModelDefinitionModel type)
        {
            return type.HasMapModelDefinitionMapping() ? type.Mapping : null;
        }
    }
}