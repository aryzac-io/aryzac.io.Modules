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


// Commands
const deleteClientCommand = async (id: string) => {



	const deleteClientCommand = await clientsServiceProxy.deleteClientCommand(id);
};



// table Options
const tableHeaders = [
  {
	key: 'clientName',
	label: t("table.clientName"),
    data: (item: ClientDto) => {
      const lastName = item.lastName || '';
      const firstName = item.firstName || '';
      const otherNames = item.otherNames || '';
      const mappedExpression = `${lastName}, ${firstName} ${otherNames}`;
      return mappedExpression;
    }
  },
];

const tableActions = [
  {
    label: t("table.actions.delete.label"),
    icon: t("table.actions.delete.icon"),
    action: async (item: ClientDto) => {
      await deleteClientCommand(item.id);
    },
  },
  {
    label: t("table.actions.edit.label"),
    icon: t("table.actions.edit.icon"),
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