// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Aryzac.IO.Modules.Client.Templates.Files.Composables.Controls.UseTableOptions
{
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Metadata.Models;
    using Intent.Modelers.Types.ServiceProxies.Api;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Modules.Common.TypeScript.Templates;
    using Intent.Modules.Metadata.WebApi.Models;
    using Intent.Templates;
    using Aryzac.IO.Modules.Client.Api;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseTableOptions\UseTableOptionsTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class UseTableOptionsTemplate : TypeScriptTemplateBase<Aryzac.IO.Modules.Client.Api.TableModel>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\nimport type { ComposerTranslation } from \"@nuxtjs/i18n/dist/runtime/composables" +
                    "\";\r\n");
            
            #line 15 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseTableOptions\UseTableOptionsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DtoTypeImports));
            
            #line default
            #line hidden
            this.Write("\r\n\r\nexport const use");
            
            #line 17 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseTableOptions\UseTableOptionsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.InternalElement.GetFirstParentOfType(ComponentModel.SpecializationTypeId).Name.ToPascalCase()));
            
            #line default
            #line hidden
            
            #line 17 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseTableOptions\UseTableOptionsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Options = (t: ComposerTranslation) => {\r\n\r\n");
            
            #line 19 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseTableOptions\UseTableOptionsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(CommandAndQueryServiceProxyComposables));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n");
            
            #line 21 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseTableOptions\UseTableOptionsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Commands));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n");
            
            #line 23 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseTableOptions\UseTableOptionsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TableHeaders));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n");
            
            #line 25 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseTableOptions\UseTableOptionsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TableActions));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}