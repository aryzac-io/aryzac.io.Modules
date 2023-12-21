using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiElementModelExtensions", Version = "1.0")]

namespace Aryzac.Io.Modules.Client.Api
{
    public static class TableColumnModelStereotypeExtensions
    {
        public static TableColumnSettings GetTableColumnSettings(this TableColumnModel model)
        {
            var stereotype = model.GetStereotype("Table Column Settings");
            return stereotype != null ? new TableColumnSettings(stereotype) : null;
        }


        public static bool HasTableColumnSettings(this TableColumnModel model)
        {
            return model.HasStereotype("Table Column Settings");
        }

        public static bool TryGetTableColumnSettings(this TableColumnModel model, out TableColumnSettings stereotype)
        {
            if (!HasTableColumnSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new TableColumnSettings(model.GetStereotype("Table Column Settings"));
            return true;
        }

        public class TableColumnSettings
        {
            private IStereotype _stereotype;

            public TableColumnSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public string Title()
            {
                return _stereotype.GetProperty<string>("Title");
            }

            public bool Sortable()
            {
                return _stereotype.GetProperty<bool>("Sortable");
            }

        }

    }
}