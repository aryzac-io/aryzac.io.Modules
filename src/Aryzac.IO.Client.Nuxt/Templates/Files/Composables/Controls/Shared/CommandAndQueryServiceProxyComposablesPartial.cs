using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Xml.Linq;
using Aryzac.IO.Modules.Client.Api;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.Modelers.Types.ServiceProxies.Api;
using Intent.Modelers.WebClient.Api;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.TypeScript.TypeResolvers;
using Intent.Modules.Metadata.WebApi.Models;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;
using static Aryzac.IO.Modules.Client.Api.LocaleModelStereotypeExtensions;

namespace Aryzac.IO.Client.Nuxt.Templates.Files.Composables.Controls.Shared
{
    partial class CommandAndQueryServiceProxyComposables
    {
        public CommandAndQueryServiceProxyComposables(IElement element)
        {
            Element = element;
        }

        public IElement Element { get; set; }

        public List<ServiceProxyModel> CommandsAndQueries => GetCommandsAndQueries();

        private List<ServiceProxyModel> GetCommandsAndQueries()
        {
            var commandModels = GetCommandModels();
            var queryModels = GetQueryModels();

            var allModels = commandModels.Concat(queryModels);
            return allModels.Distinct().ToList();
        }

        private IEnumerable<ServiceProxyModel> GetCommandModels()
        {
            return Element.ChildElements
                .GetElementsOfType(ComponentCommandModel.SpecializationTypeId, true)
                .Select(x => new ComponentCommandModel(x).Mapping?.Element.AsOperationModel().ParentService)
                .Where(m => m is not null);
        }

        private IEnumerable<ServiceProxyModel> GetQueryModels()
        {
            return Element.ChildElements
                .GetElementsOfType(ComponentQueryModel.SpecializationTypeId, true)
                .Select(x => new ComponentQueryModel(x).Mapping?.Element.AsOperationModel().ParentService)
                .Where(m => m is not null);
        }
    }
}
