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
    public class ComponentActionsModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper
    {
        public const string SpecializationType = "Component Actions";
        public const string SpecializationTypeId = "a126b934-3b67-41cf-8fcc-8bc6f5473d9a";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public ComponentActionsModel(IElement element, string requiredType = SpecializationType)
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

        public IList<CommandReferenceModel> CommandReferences => _element.ChildElements
            .GetElementsOfType(CommandReferenceModel.SpecializationTypeId)
            .Select(x => new CommandReferenceModel(x))
            .ToList();

        public IList<CommandModel> Commands => _element.ChildElements
            .GetElementsOfType(CommandModel.SpecializationTypeId)
            .Select(x => new CommandModel(x))
            .ToList();

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(ComponentActionsModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ComponentActionsModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class ComponentActionsModelExtensions
    {

        public static bool IsComponentActionsModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == ComponentActionsModel.SpecializationTypeId;
        }

        public static ComponentActionsModel AsComponentActionsModel(this ICanBeReferencedType type)
        {
            return type.IsComponentActionsModel() ? new ComponentActionsModel((IElement)type) : null;
        }
    }
}