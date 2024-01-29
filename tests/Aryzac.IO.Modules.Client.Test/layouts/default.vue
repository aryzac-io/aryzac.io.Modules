<i18n lang="yaml" src="@/locales/default.i18n.yaml" />

<script setup lang="ts">
const { t } = useI18n();

// Setup SEO Metadata
useSeoMeta({
  ogImage: "[og:image]",
  twitterTitle: "[twitter:title]",
  twitterDescription: "[twitter:description]",
  twitterImage: "[twitter:image]",
  twitterCard: "summary",
});

// Setup Head
useHead({
  htmlAttrs: {
    lang: "en",
  },
  link: [
    {
      rel: "icon",
      type: "image/x-icon",
      href: "/favicon.ico",
    },
  ],
});

const { clearSections } = useNavigationStore();
const { setupSection, setupSectionItem } = useNavigationSetup();

clearSections(true);

// Setup Appbar
setupSectionItem(
  "appbar",
  t("appbar.navigation.home.label"),
  null,
  "/"
);
setupSectionItem(
  "appbar",
  t("appbar.navigation.clients.label"),
  null,
  "/Clients"
);
setupSectionItem(
  "appbar",
  t("appbar.navigation.dashboard.label"),
  null,
  "/dashboard"
);


// Setup Breadcrumb
setupSectionItem(
  "breadcrumb", 
  t("breadcrumb.navigation.home.label"), 
  t("breadcrumb.navigation.home.icon"), 
  "/"
);
</script>

<template>
  <div>
  
    <div class="min-h-screen">

      <layout-appbar />
      <layout-breadcrumbs />
      <main class="px-4 sm:px-6 lg:px-8 py-10">
        <!-- Your content -->
        <slot />
      </main>
    </div>
  </div>
</template>

<style>
html {
  @apply h-full bg-gray-100;
}

body {
  @apply h-full;
}
</style>

