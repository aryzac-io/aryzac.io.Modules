<i18n lang="yaml" src="@/locales/components/Clients/EditClient.i18n.yaml" />

<script setup lang="ts">


import type { EditClientProps } from '~/structs/components/clients/edit-client.props';

import type { ClientDto } from '~/structs/dto/clients/client.dto';


const { t } = useI18n();


const props = defineProps<EditClientProps>();


const clientsServiceProxy = useClientsServiceProxy();

// Queries
const { 
  data: editClientGetClientByIdQueryData, 
  pending: editClientGetClientByIdQueryPending, 
  error: editClientGetClientByIdQueryError , 
  execute: editClientGetClientByIdQueryExecute, 
  refresh: editClientGetClientByIdQueryRefresh, 
  status: editClientGetClientByIdQueryStatus 
} = await clientsServiceProxy.getClientByIdQuery(props.clientId);

// Model
interface ModelInterface {
  id: string;
  firstName: string;
  lastName: string;
  otherNames?: string;
  titleId: string;
  receivePromotions: boolean;
  notes: string;
}

const model: ModelInterface = reactive({
  id: "",
  firstName: "",
  lastName: "",
  otherNames: "",
  titleId: "",
  receivePromotions: "",
  notes: "",
});

watchEffect(async () => {
  if (editClientGetClientByIdQueryData.value) {
    model.id = editClientGetClientByIdQueryData.value.id;
    model.firstName = editClientGetClientByIdQueryData.value.firstName;
    model.lastName = editClientGetClientByIdQueryData.value.lastName;
    model.otherNames = editClientGetClientByIdQueryData.value.otherNames;
    model.titleId = editClientGetClientByIdQueryData.value.titleId;
    model.receivePromotions = editClientGetClientByIdQueryData.value.receivePromotions;
    model.notes = editClientGetClientByIdQueryData.value.notes;
  }
});



onMounted(() => {
  editClientGetClientByIdQueryExecute();
});
</script>


<template>
  <ui-heading-page
    :title="headingTitle"
    :attributes="headingAttributes"
    :actions="headingActions"
  />
</template>

