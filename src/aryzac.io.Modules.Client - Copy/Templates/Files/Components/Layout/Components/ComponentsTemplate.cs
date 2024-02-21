//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:7.0.15
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Aryzac.IO.Modules.Client.Templates.Files.Components.Layout.Components {
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Metadata.Models;
    using System;
    
    
    public partial class ComponentsTemplate : IntentTemplateBase<object> {
        
        public override string TransformText() {
            this.GenerationEnvironment = null;
            
            #line 8 ""
            this.Write(@"
// update
import AppbarNavigation from ""~/components/layout/appbar/navigation.vue"";
import SidebarNavigation from ""~/components/layout/sidebar/navigation.vue"";

export const components = {
  appbar: AppbarNavigation,
  sidebar: SidebarNavigation,
};
");
            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
        
        public override void Initialize() {
            base.Initialize();
        }
    }
}