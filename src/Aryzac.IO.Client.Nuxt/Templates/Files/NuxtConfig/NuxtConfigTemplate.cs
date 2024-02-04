// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Aryzac.IO.Client.Nuxt.Templates.Files.NuxtConfig
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
    
    #line 1 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Client.Nuxt\Templates\Files\NuxtConfig\NuxtConfigTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class NuxtConfigTemplate : TypeScriptTemplateBase<object>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\n\r\n// https://nuxt.com/docs/api/configuration/nuxt-config\r\nexport default define" +
                    "NuxtConfig({\r\n  devtools: { enabled: true },\r\n\r\n  runtimeConfig: {\r\n    public: " +
                    "{\r\n");
            
            #line 19 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Client.Nuxt\Templates\Files\NuxtConfig\NuxtConfigTemplate.tt"
 foreach (var serviceProxy in GetServiceProxies()) 
{ 
            
            #line default
            #line hidden
            this.Write("      ");
            
            #line 20 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Client.Nuxt\Templates\Files\NuxtConfig\NuxtConfigTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(serviceProxy.Name.ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("ApiBaseUri: \'\', // Default to an empty string, automatically set at runtime using" +
                    " process.env.NUXT_PUBLIC_");
            
            #line 20 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Client.Nuxt\Templates\Files\NuxtConfig\NuxtConfigTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(serviceProxy.Name.ToSnakeCase().ToUpper()));
            
            #line default
            #line hidden
            this.Write("_API_BASE_URI\r\n");
            
            #line 21 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Client.Nuxt\Templates\Files\NuxtConfig\NuxtConfigTemplate.tt"

}
            
            #line default
            #line hidden
            this.Write(@"
      apiBaseUri: '', // Default to an empty string, automatically set at runtime using process.env.NUXT_PUBLIC_API_BASE_URI
    }
  },

  modules: [
    // https://nuxt.com/modules/i18n
    ""@nuxtjs/i18n"",
    // https://nuxt.com/modules/tailwindcss
    ""@nuxtjs/tailwindcss"",
    // https://nuxtseo.com/nuxt-seo/getting-started/installation
    ""@nuxtseo/module"",
    // https://pinia.vuejs.org/ssr/nuxt.html
    ""@pinia/nuxt"",
    // https://nuxt.com/modules/icon
    ""nuxt-icon"",
  ],

");
            
            #line 41 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Client.Nuxt\Templates\Files\NuxtConfig\NuxtConfigTemplate.tt"

    var defaultLocale = "";

    foreach (var locale in GetLocales()[0].Locales)
    {
        locale.TryGetDefaultLocale(out var defaultLocaleSettings);

        if (defaultLocaleSettings is not null)
        {
            defaultLocale = locale.Name;
        }
    }

            
            #line default
            #line hidden
            this.Write("\r\n  i18n: {\r\n    strategy: \"prefix_except_default\",\r\n    defaultLocale: \"");
            
            #line 57 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Client.Nuxt\Templates\Files\NuxtConfig\NuxtConfigTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(defaultLocale));
            
            #line default
            #line hidden
            this.Write("\",\r\n    fallbackLocale: \"");
            
            #line 58 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Client.Nuxt\Templates\Files\NuxtConfig\NuxtConfigTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(defaultLocale));
            
            #line default
            #line hidden
            this.Write("\",\r\n    locales: [\r\n");
            
            #line 60 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Client.Nuxt\Templates\Files\NuxtConfig\NuxtConfigTemplate.tt"
 foreach (var locale in GetLocales()[0].Locales)
   {
      locale.TryGetLocaleSettings(out var localeSettings);

            
            #line default
            #line hidden
            this.Write("      {\r\n        code: \"");
            
            #line 65 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Client.Nuxt\Templates\Files\NuxtConfig\NuxtConfigTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(locale.Name.ToLower()));
            
            #line default
            #line hidden
            this.Write("\",\r\n        iso: \"");
            
            #line 66 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Client.Nuxt\Templates\Files\NuxtConfig\NuxtConfigTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(localeSettings.ISOCode()));
            
            #line default
            #line hidden
            this.Write("\", \r\n      },\r\n");
            
            #line 68 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Client.Nuxt\Templates\Files\NuxtConfig\NuxtConfigTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write(@"    ],
    baseUrl: ""http://localhost:3000"",
  },

  app: {
    head: {
      titleTemplate: ""%s %separator %siteName"",
      templateParams: {
        separator: ""-"",
      },
    },
  },

  site: {
    url: ""http://localhost:3000"",
    name: """);
            
            #line 84 "D:\src\aryzac-io\aryzac.io.Modules\src\Aryzac.IO.Client.Nuxt\Templates\Files\NuxtConfig\NuxtConfigTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ExecutionContext.GetApplicationConfig().Name.Replace(".", " ").ToKebabCase()));
            
            #line default
            #line hidden
            this.Write("\",\r\n    description: \"Welcome\",\r\n  },\r\n\r\n  ogImage: {\r\n  },\r\n\r\n  tailwindcss: {\r\n" +
                    "    config: {\r\n      plugins: [\r\n        require(\"@tailwindcss/forms\"),\r\n       " +
                    " require(\"@tailwindcss/typography\"),\r\n      ],\r\n    },\r\n  },\r\n});\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
