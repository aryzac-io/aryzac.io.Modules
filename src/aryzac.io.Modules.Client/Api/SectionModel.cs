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
    public class SectionModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper
    {
        public const string SpecializationType = "Section";
        public const string SpecializationTypeId = "d15b8bed-441b-4ef7-9541-f7df1c31fb48";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public SectionModel(IElement element, string requiredType = SpecializationType)
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

        public IList<CheckboxModel> Checkboxes => _element.ChildElements
            .GetElementsOfType(CheckboxModel.SpecializationTypeId)
            .Select(x => new CheckboxModel(x))
            .ToList();

        public IList<DatePickerModel> DatePickers => _element.ChildElements
            .GetElementsOfType(DatePickerModel.SpecializationTypeId)
            .Select(x => new DatePickerModel(x))
            .ToList();

        public IList<RadioButtonModel> RadioButtons => _element.ChildElements
            .GetElementsOfType(RadioButtonModel.SpecializationTypeId)
            .Select(x => new RadioButtonModel(x))
            .ToList();

        public IList<SwitchModel> Switches => _element.ChildElements
            .GetElementsOfType(SwitchModel.SpecializationTypeId)
            .Select(x => new SwitchModel(x))
            .ToList();

        public IList<TextAreaModel> TextAreas => _element.ChildElements
            .GetElementsOfType(TextAreaModel.SpecializationTypeId)
            .Select(x => new TextAreaModel(x))
            .ToList();

        public IList<TextboxModel> Textboxes => _element.ChildElements
            .GetElementsOfType(TextboxModel.SpecializationTypeId)
            .Select(x => new TextboxModel(x))
            .ToList();

        public IList<TimePickerModel> TimePickers => _element.ChildElements
            .GetElementsOfType(TimePickerModel.SpecializationTypeId)
            .Select(x => new TimePickerModel(x))
            .ToList();

        public IList<SelectModel> Selects => _element.ChildElements
            .GetElementsOfType(SelectModel.SpecializationTypeId)
            .Select(x => new SelectModel(x))
            .ToList();

        public IList<FileModel> Files => _element.ChildElements
            .GetElementsOfType(FileModel.SpecializationTypeId)
            .Select(x => new FileModel(x))
            .ToList();

        public IList<SliderModel> Sliders => _element.ChildElements
            .GetElementsOfType(SliderModel.SpecializationTypeId)
            .Select(x => new SliderModel(x))
            .ToList();

        public IList<LabelModel> Labels => _element.ChildElements
            .GetElementsOfType(LabelModel.SpecializationTypeId)
            .Select(x => new LabelModel(x))
            .ToList();

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(SectionModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SectionModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class SectionModelExtensions
    {

        public static bool IsSectionModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == SectionModel.SpecializationTypeId;
        }

        public static SectionModel AsSectionModel(this ICanBeReferencedType type)
        {
            return type.IsSectionModel() ? new SectionModel((IElement)type) : null;
        }
    }
}