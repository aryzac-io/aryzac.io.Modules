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
    
    #line 1 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\Script.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class Script : ComponentTemplate
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\n<script setup lang=\"ts\">\r\n\r\n");
            this.Write("\r\n");
            
            #line 12 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\./TypeImport.tt"
 if (Model.Parameters != null) { 
            
            #line default
            #line hidden
            this.Write("import type { ");
            
            #line 13 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\./TypeImport.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write("Props } from \'~/structs/components/");
            
            #line 13 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\./TypeImport.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.InternalElement.ParentElement.Name.ToPascalCase().ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("/");
            
            #line 13 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\./TypeImport.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name.ToKebabCase()));
            
            #line default
            #line hidden
            this.Write(".props\';\r\n");
            
            #line 14 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\./TypeImport.tt"
 } 
            
            #line default
            #line hidden
            
            #line 15 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\./TypeImport.tt"
 if (Model.Model != null) { 
            
            #line default
            #line hidden
            this.Write("import type { ");
            
            #line 16 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\./TypeImport.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write("Model } from \'~/structs/components/");
            
            #line 16 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\./TypeImport.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.InternalElement.ParentElement.Name.ToPascalCase().ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("/");
            
            #line 16 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\./TypeImport.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name.ToKebabCase()));
            
            #line default
            #line hidden
            this.Write(".model\';\r\n");
            
            #line 17 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\./TypeImport.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 19 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\./TypeImport.tt"
 
  foreach (var query in Queries)
  {
    var endpoint = HttpEndpointModelFactory.GetEndpoint((IElement)query.Mapping.Element.AsOperationModel().Mapping.Element);
	
            
            #line default
            #line hidden
            this.Write("import type { ");
            
            #line 23 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\./TypeImport.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(endpoint.ReturnType.Element.Name));
            
            #line default
            #line hidden
            this.Write(" } from \'~/structs/dto/");
            
            #line 23 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\./TypeImport.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(((IElement)endpoint.ReturnType.Element).ParentElement.Name.ToPascalCase().ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("/");
            
            #line 23 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\./TypeImport.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(((IElement)endpoint.ReturnType.Element).MappedElement.Element.Name.ToKebabCase()));
            
            #line default
            #line hidden
            this.Write(".dto\';\r\n");
            
            #line 24 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\./TypeImport.tt"

  }

            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 28 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\./TypeImport.tt"
 
  foreach (var command in Commands)
  {
    var endpoint = HttpEndpointModelFactory.GetEndpoint((IElement)command.Mapping.Element.AsOperationModel().Mapping.Element);
    if (endpoint.Inputs.FirstOrDefault(x => x.Source == HttpInputSource.FromBody) != null) 
    { 
        var bodyParam = endpoint.Inputs.First(x => x.Source == HttpInputSource.FromBody);

            
            #line default
            #line hidden
            this.Write("import type { ");
            
            #line 36 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\./TypeImport.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(endpoint.InternalElement.Name));
            
            #line default
            #line hidden
            this.Write(" } from \'~/structs/dto/");
            
            #line 36 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\./TypeImport.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(((IElement)bodyParam.TypeReference.Element).ParentElement.Name.ToPascalCase().ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("/");
            
            #line 36 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\./TypeImport.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(bodyParam.TypeReference.Element.Name.ToKebabCase()));
            
            #line default
            #line hidden
            this.Write(".dto\';\r\n");
            
            #line 37 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\./TypeImport.tt"
 
    } 
  }

            
            #line default
            #line hidden
            this.Write("\r\nconst { t } = useI18n();\r\n\r\n");
            this.Write("\r\n");
            
            #line 12 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\./Properties.tt"
 if (Model.Parameters != null) { 
            
            #line default
            #line hidden
            this.Write("const props = defineProps<");
            
            #line 13 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\./Properties.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write("Props>();\r\n");
            
            #line 14 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\./Properties.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n\r\n");
            
            #line 20 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\Script.tt"

  foreach (var commandOrQuery in CommandsAndQueries)
  {

            
            #line default
            #line hidden
            this.Write("const ");
            
            #line 24 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\Script.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(commandOrQuery.Name.ToPascalCase().ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("Proxy = use");
            
            #line 24 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\Script.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(commandOrQuery.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Proxy();\r\n");
            
            #line 25 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\Script.tt"
   
  }

            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 29 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\Script.tt"
   
  if (Model.Query != null)
  {

            
            #line default
            #line hidden
            this.Write("const query = await ");
            
            #line 33 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\Script.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Query.Mapping.Element.AsOperationModel().ParentService.Name.ToPascalCase().ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("Proxy.");
            
            #line 33 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\Script.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Query.Mapping.Element.Name.ToPascalCase().ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("(");
            
            #line 33 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\Script.tt"


    foreach (var mapping in Model.Query.InternalElement.Mappings)
    {
      foreach (var mappedEnd in mapping.MappedEnds)
      {
	    
            
            #line default
            #line hidden
            this.Write("props.");
            
            #line 39 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\Script.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(mappedEnd.SourceElement.Name.ToPascalCase().ToCamelCase()));
            
            #line default
            #line hidden
            
            #line 39 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\Script.tt"

        if (mapping.MappedEnds.Last() != mappedEnd)
		{
		
            
            #line default
            #line hidden
            this.Write(", ");
            
            #line 42 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\Script.tt"

		}
	  }
	}
	
            
            #line default
            #line hidden
            this.Write(");");
            
            #line 46 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\Script.tt"

  } 
            
            #line default
            #line hidden
            
            #line 48 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\Script.tt"

  if (Model.Model != null)
  {

            
            #line default
            #line hidden
            this.Write("const model = reactive({} as ");
            
            #line 52 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\Script.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write("Model);\r\n\r\n");
            
            #line 54 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\Script.tt"
   
    if (Model.Query != null)
    {

            
            #line default
            #line hidden
            this.Write("watchEffect(async () => {\r\n  if (query.data.value) {\r\n");
            
            #line 60 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\Script.tt"
  
      foreach (var property in Model.Model.Properties)
      {

            
            #line default
            #line hidden
            this.Write("    model.");
            
            #line 64 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\Script.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.Name.ToPascalCase().ToCamelCase()));
            
            #line default
            #line hidden
            this.Write(" = query.data.value.");
            
            #line 64 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\Script.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetMappedPropertyName(property)));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 65 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\Script.tt"

      }
    }

            
            #line default
            #line hidden
            this.Write("  }\r\n});\r\n");
            
            #line 71 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\Script.tt"

  }

            
            #line default
            #line hidden
            this.Write("\r\n\r\nonMounted(() => {\r\n");
            
            #line 77 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\Script.tt"

  if (Model.Query != null)
  {

            
            #line default
            #line hidden
            this.Write("  query.execute();\r\n");
            
            #line 82 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Script\Script.tt"

  }

            
            #line default
            #line hidden
            this.Write("});\r\n</script>\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
