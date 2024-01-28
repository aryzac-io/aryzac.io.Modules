<i18n lang="yaml" src="./index.i18n.yaml" />

<script setup lang="ts">
const { t } = useI18n();

const route = useRoute();

const clientId = route.params.clientid;

const { setupSectionItem } = useNavigationSetup();

// Setup Breadcrumb
setupSectionItem(
  "breadcrumb", 
  t("breadcrumb.navigation.clients.label"), 
  null, 
  `/clients`,
  false
);
setupSectionItem(
  "breadcrumb", 
  t("breadcrumb.navigation.client.label"), 
  null, 
  `/clients/${clientId}`,
  false
);
setupSectionItem(
  "breadcrumb", 
  t("breadcrumb.navigation.invoices.label"), 
  null, 
  `/clients/[client-id]/invoices`,
  false
);
</script>

<template>
  <div>
  </div>
</template>