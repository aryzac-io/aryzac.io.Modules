<i18n lang="yaml" src="@/locales/pages/Clients/[client-id]/edit.i18n.yaml" />

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
  `/Clients`,
  false
);
setupSectionItem(
  "breadcrumb", 
  t("breadcrumb.navigation.editClient.label"), 
  null, 
  `/Clients/${clientId}/edit`,
  false
);
</script>

<template>
  <div>
    <clients-edit-client 
	    :client-id="clientId"	/>
  </div>
</template>