<i18n lang="yaml" src="./index.i18n.yaml" />

<script setup lang="ts">
const { t } = useI18n();

const route = useRoute();

const clientId = route.params.clientid;
const invoiceId = route.params.invoiceid;


</script>

<template>
  <div>
  </div>
</template>