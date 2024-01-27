<i18n lang="yaml" src="./ListClients.i18n.yaml" />

<script setup lang="ts">


const { t } = useI18n();

const props = defineProps<{
}>();
	
const clientsServiceProxy = useClientsServiceProxy();

// Queries
const { 
  data: tableGetClientsQueryData, 
  pending: tableGetClientsQueryPending, 
  error: tableGetClientsQueryError 
} = await clientsServiceProxy.getClientsQuery();




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
    :items="tableGetClientsQueryData"
    :headers="tableHeaders"
    key="id"
  />
</template>