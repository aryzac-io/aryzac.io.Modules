﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Aryzac.IO.Modules.Client.Templates.Files.Components.Component.Script
{
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Metadata.Models;
    using Aryzac.IO.Modules.Client.Api;
    using Intent.Modelers.Types.ServiceProxies.Api;
    using Intent.Modules.Metadata.WebApi.Models;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\TypeImport.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class TypeImport : ComponentTemplate
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\n");
            
            #line 12 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\TypeImport.tt"
 
  foreach (var query in Queries)
  {
    var endpoint = HttpEndpointModelFactory.GetEndpoint((IElement)query.Mapping.Element.AsOperationModel().Mapping.Element);
	
            
            #line default
            #line hidden
            this.Write("import type { ");
            
            #line 16 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\TypeImport.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(endpoint.ReturnType.Element.Name));
            
            #line default
            #line hidden
            this.Write(" } from \'~/structs/dto/");
            
            #line 16 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\TypeImport.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(((IElement)endpoint.ReturnType.Element).ParentElement.Name.ToPascalCase().ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("/");
            
            #line 16 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\TypeImport.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(((IElement)endpoint.ReturnType.Element).MappedElement.Element.Name.ToKebabCase()));
            
            #line default
            #line hidden
            this.Write(".dto\';\r\n");
            
            #line 17 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\TypeImport.tt"

  }

            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 21 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\TypeImport.tt"
 
  foreach (var command in Commands)
  {
    var endpoint = HttpEndpointModelFactory.GetEndpoint((IElement)command.Mapping.Element.AsOperationModel().Mapping.Element);
    if (endpoint.Inputs.FirstOrDefault(x => x.Source == HttpInputSource.FromBody) != null) 
    { 
        var bodyParam = endpoint.Inputs.First(x => x.Source == HttpInputSource.FromBody);

            
            #line default
            #line hidden
            this.Write("import type { ");
            
            #line 29 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\TypeImport.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(endpoint.InternalElement.Name));
            
            #line default
            #line hidden
            this.Write(" } from \'~/structs/dto/");
            
            #line 29 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\TypeImport.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(((IElement)bodyParam.TypeReference.Element).ParentElement.Name.ToPascalCase().ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("/");
            
            #line 29 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\TypeImport.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(bodyParam.TypeReference.Element.Name.ToKebabCase()));
            
            #line default
            #line hidden
            this.Write(".dto\';\r\n");
            
            #line 30 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\TypeImport.tt"
 
    } 
  }

            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}