<i18n lang="yaml" src="@/locales/pages/Clients/[client-id]/invoices.i18n.yaml" />

<script setup lang="ts">
const { t } = useI18n();

const route = useRoute();

const clientId = route.params.clientid;


</script>

<template>
  <div>
    <invoices-list-invoices 
		/>
  </div>
</template>