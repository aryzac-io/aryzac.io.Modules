<i18n lang="yaml" src="@/locales/pages/Clients/index.i18n.yaml" />

<script setup lang="ts">
const { t } = useI18n();



const { setupSectionItem } = useNavigationSetup();

// Setup Breadcrumb
setupSectionItem(
  "breadcrumb", 
  t("breadcrumb.navigation.clients.label"), 
  null, 
  `/Clients`,
  false
);
</script>

<template>
  <div>
  </div>
</template>