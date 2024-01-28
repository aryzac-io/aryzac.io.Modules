<i18n lang="yaml" src="./index.i18n.yaml" />

<script setup lang="ts">
const { t } = useI18n();



const { setupSectionItem } = useNavigationSetup();

// Setup Breadcrumb
setupSectionItem(
  "breadcrumb", 
  t("breadcrumb.navigation.clients.label"), 
  null, 
  `/clients`,
  false
);
</script>

<template>
  <div>
    <clients-list-clients 
		/>
  </div>
</template>