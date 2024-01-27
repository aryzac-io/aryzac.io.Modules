<i18n lang="yaml" src="./ListClients.i18n.yaml" />

<script setup lang="ts">
import type { ClientDto } from '~/structs/dto/clients/client.dto';

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

const tableActions = [
  {
    label: t("table.actions.edit.label"),
    action: async (item: ClientDto) => {
      await navigateTo(`/clients/${item.id}`);
    },
  },
];

</script>

<template>
  <ui-view-table
    :items="tableGetClientsQueryData"
    :headers="tableHeaders"
    :actions="tableActions"
    key="id"
  />
</template>