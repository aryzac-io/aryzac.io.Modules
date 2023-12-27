// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  devtools: { enabled: true },

  modules: [
    // https://tailwindcss.nuxtjs.org/tailwind/config
    "@nuxtjs/tailwindcss",
    // https://github.com/nuxt-modules/icon
    "nuxt-icon",
  ],

  tailwindcss: {
    config: {
      plugins: [
        require("@tailwindcss/forms"),
        require("@tailwindcss/typography"),
      ],
    },
  },
});
