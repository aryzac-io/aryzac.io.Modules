// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  devtools: { enabled: true },

  runtimeConfig: {
    public: {
      clientsServiceApiBaseUri: '', // Default to an empty string, automatically set at runtime using process.env.NUXT_PUBLIC_CLIENTS_SERVICE_API_BASE_URI
      apiBaseUri: '', // Default to an empty string, automatically set at runtime using process.env.NUXT_PUBLIC_API_BASE_URI
    }
  },

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
    name: "aryzac-io-modules-client-test",
    description: "Welcome",
  },

  ogImage: {
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
