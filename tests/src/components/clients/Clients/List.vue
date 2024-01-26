<i18n lang="yaml" src="./List.i18n.yaml" />

<script setup lang="ts">


const { t } = useI18n();

const props = defineProps<{
}>();
	
const clientsServiceProxy = useClientsServiceProxy();

// Queries
const { 
  data: tableGetClientsData, 
  pending: tableGetClientsPending, 
  error: tableGetClientsError 
} = await clientsServiceProxy.getClients();




// table Options


//table Options
const tableHeaders = [
  {
	key: 'firstName',
	label: t("table.firstName"),
  },
  {
	key: 'lastName',
	label: t("table.lastName"),
  },
  {
	key: 'otherNames',
	label: t("table.otherNames"),
  },
];

</script>

<template>
  <ui-view-table
    :items="tableGetClientsData"
    :headers="tableHeaders"
    key="id"
  />
</template>