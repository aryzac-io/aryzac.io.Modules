<i18n lang="yaml">
en:
  [table]:
    
</i18n>

<script setup lang="ts">


const { t } = useI18n();

const props = defineProps<{
}>();
	
const clientsServiceProxy = useClientsServiceProxy();

// Queries
const { 
  data: [table]GetClientsData, 
  pending: [table]GetClientsPending, 
  error: [table]GetClientsError 
} = await clientsServiceProxy.getClients();




// [table] Options


//[table] Options
const [table]Headers = [
];

</script>

<template>
  <ui-view-table
    :items="[table]GetClientsData"
    :headers="[table]Headers"
    key="id"
  />
</template>