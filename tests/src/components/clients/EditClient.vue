<i18n lang="yaml" src="./EditClient.i18n.yaml" />

<script setup lang="ts">
import type { ClientDto } from '~/structs/dto/clients/client.dto';
import type { ChangeNameClientCommand } from '~/structs/dto/clients/change-name-client-command.dto';

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

// Commands
const saveChangeNameClientCommand = async () => {

  const command: ChangeNameClientCommand = {
    id: model.id,
    firstName: model.firstName,
    lastName: model.lastName,
    otherNames: model.otherNames,
  };

  const id = props.clientId;
          
	const changeNameClientCommand = await clientsServiceProxy.changeNameClientCommand(id, command);
};

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

    <template #actions>
      <button
        type="button"
        @click="saveChangeNameClientCommand()"
        class="rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
      >
        {{ t('personalInformation.actions.save') }}
      </button>
    </template>
    
  </ui-editor-section>
</template>