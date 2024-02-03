// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Aryzac.IO.Modules.Client.Templates.Files.Composables.Controls.UseHeadingOptions
{
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Modules.Common.TypeScript.Templates;
    using Intent.Templates;
    using Intent.Metadata.Models;
    using Aryzac.IO.Modules.Client.Api;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseHeadingOptions\UseHeadingOptionsTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class UseHeadingOptionsTemplate : TypeScriptTemplateBase<Aryzac.IO.Modules.Client.Api.HeadingModel>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\nimport type { ComposerTranslation } from \"@nuxtjs/i18n/dist/runtime/composables" +
                    "\";\r\n");
            
            #line 13 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseHeadingOptions\UseHeadingOptionsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(DtoTypeImports));
            
            #line default
            #line hidden
            this.Write("\r\n\r\nexport const use");
            
            #line 15 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseHeadingOptions\UseHeadingOptionsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.InternalElement.GetFirstParentOfType(ComponentModel.SpecializationTypeId).Name.ToPascalCase()));
            
            #line default
            #line hidden
            
            #line 15 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseHeadingOptions\UseHeadingOptionsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name.ToPascalCase()));
            
            #line default
            #line hidden
            this.Write("Options = async (\r\n");
            
            #line 16 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseHeadingOptions\UseHeadingOptionsTemplate.tt"
 if (GetComponent().Parameters != null) { 
            
            #line default
            #line hidden
            this.Write("  props: ");
            
            #line 17 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseHeadingOptions\UseHeadingOptionsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetComponent().Name));
            
            #line default
            #line hidden
            this.Write("Props, \r\n");
            
            #line 18 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseHeadingOptions\UseHeadingOptionsTemplate.tt"
 } 
            
            #line default
            #line hidden
            
            #line 18 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseHeadingOptions\UseHeadingOptionsTemplate.tt"
 if (GetComponent().Model != null) { 
            
            #line default
            #line hidden
            this.Write("  model: ");
            
            #line 19 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseHeadingOptions\UseHeadingOptionsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetComponent().Name));
            
            #line default
            #line hidden
            this.Write("Model, \r\n");
            
            #line 20 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseHeadingOptions\UseHeadingOptionsTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("  t: ComposerTranslation\r\n) => {\r\n\r\n");
            
            #line 23 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseHeadingOptions\UseHeadingOptionsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(CommandAndQueryServiceProxyComposables));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n");
            
            #line 25 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseHeadingOptions\UseHeadingOptionsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(TitleComputed));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n");
            
            #line 27 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseHeadingOptions\UseHeadingOptionsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Attributes));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n");
            
            #line 29 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseHeadingOptions\UseHeadingOptionsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Commands));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n");
            
            #line 31 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseHeadingOptions\UseHeadingOptionsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Actions));
            
            #line default
            #line hidden
            this.Write("\r\n\r\nreturn {\r\n");
            
            #line 34 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseHeadingOptions\UseHeadingOptionsTemplate.tt"
 if (HasTitle()) { 
            
            #line default
            #line hidden
            this.Write("  title,\r\n");
            
            #line 36 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseHeadingOptions\UseHeadingOptionsTemplate.tt"
 } 
            
            #line default
            #line hidden
            
            #line 37 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseHeadingOptions\UseHeadingOptionsTemplate.tt"
 if (HasAttributes()) { 
            
            #line default
            #line hidden
            this.Write("  attributes,\r\n");
            
            #line 39 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseHeadingOptions\UseHeadingOptionsTemplate.tt"
 } 
            
            #line default
            #line hidden
            
            #line 40 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseHeadingOptions\UseHeadingOptionsTemplate.tt"
 if (HasActions()) { 
            
            #line default
            #line hidden
            this.Write("\tactions,\r\n");
            
            #line 42 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseHeadingOptions\UseHeadingOptionsTemplate.tt"
 } 
            
            #line default
            #line hidden
            
            #line 43 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseHeadingOptions\UseHeadingOptionsTemplate.tt"
 foreach (var command in HeadingCommands()) {
            
            #line default
            #line hidden
            this.Write("\t");
            
            #line 44 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseHeadingOptions\UseHeadingOptionsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(command.Mapping.Element.Name.ToPascalCase().ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 45 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Composables\Controls\UseHeadingOptions\UseHeadingOptionsTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("};\r\n\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
