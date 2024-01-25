<i18n lang="yaml">
en:
  newSection:
    title: Personal Information
    description: This information will be displayed publicly so be careful what you share.
    firstNameTextbox:
      label: Firstname
    lastNameTextbox:
      label: Lastname
    otherNamesTextbox:
      label: Other Names
    
</i18n>

<script setup lang="ts">
import type { ClientDto } from '~/structs/dto/clients/client.dto';

const { t } = useI18n();

const props = defineProps<{
  id: string,
}>();
	
const clientsServiceProxy = useClientsServiceProxy();

// Queries
const { 
  data: newComponent2GetClientByIdData, 
  pending: newComponent2GetClientByIdPending, 
  error: newComponent2GetClientByIdError 
} = await clientsServiceProxy.getClientById(props.id);

// Model
interface ModelInterface {
  id: string;
  firstName: string;
  lastName: string;
  otherNames?: string;
}

const model: ModelInterface = reactive({
  id: "",
  firstName: "",
  lastName: "",
  otherNames: "",
});

watchEffect(async () => {
  if (newComponent2GetClientByIdData.value) {
    model.id = newComponent2GetClientByIdData.value.id;
    model.firstName = newComponent2GetClientByIdData.value.firstName;
    model.lastName = newComponent2GetClientByIdData.value.lastName;
    model.otherNames = newComponent2GetClientByIdData.value.otherNames;
  }
})

// Commands
const saveChangeNameClient = async () => {

  const command: ChangeNameClientCommand = {
    id: model.id,
    firstName: model.firstName,
    lastName: model.lastName,
    otherNames: model.otherNames,
  };

  const id: string = props.id;

	const changeNameClient = await clientsServiceProxy.changeNameClient(id, command);
};

// NewSection Options

</script>

<template>
  <ui-editor-section
    :title="t('newSection.title')"
    :description="t('newSection.description')"
  >
     <ui-input-textbox 
       v-model="model.firstName" 
       :label="t('newSection.firstNameTextbox.label')" />
     <ui-input-textbox 
       v-model="model.lastName" 
       :label="t('newSection.lastNameTextbox.label')" />
     <ui-input-textbox 
       v-model="model.otherNames" 
       :label="t('newSection.otherNamesTextbox.label')" />

    <template #actions>
      <button
        type="button"
        @click="saveChangeNameClient()"
        class="rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
      >
        Save
      </button>
    </template>
    
  </ui-editor-section>
</template>