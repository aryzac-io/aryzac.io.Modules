﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Aryzac.IO.Modules.Client.Templates.Files.Components.Component.Template
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
    
    #line 1 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Template\Template.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class Template : ComponentTemplate
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\n");
            
            #line 12 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Template\Template.tt"
 Model.TryGetComponentSettings(out var componentSettings); 
            
            #line default
            #line hidden
            
            #line 13 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Template\Template.tt"
 if (componentSettings is not null && componentSettings.SeparateTemplate()) { 
            
            #line default
            #line hidden
            this.Write("<template src=\"./");
            
            #line 14 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Template\Template.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Model.Name));
            
            #line default
            #line hidden
            this.Write(".template.html\" />\r\n");
            
            #line 15 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Template\Template.tt"
 } else { 
            
            #line default
            #line hidden
            this.Write("<template>\r\n");
            
            #line 17 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Template\Template.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(HtmlTemplate));
            
            #line default
            #line hidden
            this.Write("\r\n</template>\r\n");
            
            #line 19 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Modules.Client\Templates\Files\Components\Component\Template\Template.tt"
 } 
            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}