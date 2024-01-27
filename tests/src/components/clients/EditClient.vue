<i18n lang="yaml" src="./EditClient.i18n.yaml" />

<script setup lang="ts">
import type { ClientDto } from '~/structs/dto/clients/client.dto';

const { t } = useI18n();

const props = defineProps<{
  clientId: string,
}>();
	
const clientsServiceProxy = useClientsServiceProxy();

// Queries
const { 
  data: editClientGetClientByIdQueryData, 
  pending: editClientGetClientByIdQueryPending, 
  error: editClientGetClientByIdQueryError 
} = await clientsServiceProxy.getClientByIdQuery(props.clientId);

// Model
interface ModelInterface {
  id: string;
  firstName: string;
  lastName: string;
  otherNames?: string;
  titleId: string;
}

const model: ModelInterface = reactive({
  id: "",
  firstName: "",
  lastName: "",
  otherNames: "",
  titleId: "",
});

watchEffect(async () => {
  if (editClientGetClientByIdQueryData.value) {
    model.id = editClientGetClientByIdQueryData.value.id;
    model.firstName = editClientGetClientByIdQueryData.value.firstName;
    model.lastName = editClientGetClientByIdQueryData.value.lastName;
    model.otherNames = editClientGetClientByIdQueryData.value.otherNames;
    model.titleId = editClientGetClientByIdQueryData.value.titleId;
  }
});



// Personal Information Options

</script>

<template>
  <ui-editor-section
    :title="t('personalInformation.title')"
    :description="t('personalInformation.description')"
  >
     <ui-input-textbox 
       v-model="model.firstName" 
       :label="t('personalInformation.firstNameTextBox.label')" />
     <ui-input-textbox 
       v-model="model.lastName" 
       :label="t('personalInformation.lastNameTextBox.label')" />
     <ui-input-textbox 
       v-model="model.otherNames" 
       :label="t('personalInformation.otherNamesTextBox.label')" />
  </ui-editor-section>
</template>