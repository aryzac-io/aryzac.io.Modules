// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  devtools: { enabled: true },

  modules: [
    // https://nuxt.com/modules/i18n
    "@nuxtjs/i18n",
    // https://nuxt.com/modules/tailwindcss
    "@nuxtjs/tailwindcss",
    // https://nuxtseo.com/nuxt-seo/getting-started/installation
    "@nuxtseo/module",
    // https://pinia.vuejs.org/ssr/nuxt.html
    "@pinia/nuxt",
    // https://nuxt.com/modules/icon
    "nuxt-icon",
  ],

  i18n: {
    strategy: "prefix_except_default",
    defaultLocale: "en",
    locales: [
      {
        code: "en",
        iso: "en-US", // Will be used as "catchall" locale by default
      },
    ],
    baseUrl: "http://localhost:3000",
  },

  app: {
    head: {
      titleTemplate: "%s %separator %siteName",
      templateParams: {
        separator: "-",
      },
    },
  },

  site: {
    url: "http://localhost:3000",
    name: "Default Site",
    description: "Welcome",
  },

  ogImage: {
    debug: true,
  },

  tailwindcss: {
    config: {
      plugins: [
        require("@tailwindcss/forms"),
        require("@tailwindcss/typography"),
      ],
    },
  },
});
