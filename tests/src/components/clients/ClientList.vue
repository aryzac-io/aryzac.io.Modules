<i18n lang="yaml">
en:
  newSection:
    title: NewSection
    description: ''
    newTable:
      lastName: LastName
      name: Name
      otherNames: OtherNames
    
</i18n>

<script setup lang="ts">
import type { ClientDto } from '~/structs/dto/clients/client.dto';

const { t } = useI18n();

const props = defineProps<{
}>();
	
const clientsServiceProxy = useClientsServiceProxy();

// Queries
const { 
  data: clientListGetClientsData, 
  pending: clientListGetClientsPending, 
  error: clientListGetClientsError 
} = await clientsServiceProxy.getClients();
const { 
  data: newTableGetClientsData, 
  pending: newTableGetClientsPending, 
  error: newTableGetClientsError 
} = await clientsServiceProxy.getClients();

// Model
interface ModelInterface {
}

const model: ModelInterface = reactive({
});

watchEffect(async () => {
  if (clientListGetClientsData.value) {
  }
})



// NewSection

// NewTable
const newTableHeaders = [
  {
	key: 'lastName',
	label: t("newSection.newTable.lastName"),
  },
  {
	key: 'firstName',
	label: t("newSection.newTable.name"),
  },
  {
	key: 'otherNames',
	label: t("newSection.newTable.otherNames"),
  },
];
</script>

<template>
  <ui-editor-section
    :title="t('newSection.title')"
    :description="t('newSection.description')"
  >
  <ui-view-table
    :items="newTableGetClientsData"
    :headers="newTableHeaders"
    key="id"
  />
  </ui-editor-section>
</template>