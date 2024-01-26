<i18n lang="yaml">
en:
  personalInformation:
    title: Personal Information
    description: This information will be displayed publicly so be careful what you share.
    firstName:
      label: FirstName
    lastName:
      label: LastName
    otherNames:
      label: OtherNames
    actions:
      save: asdfasdf
    
</i18n>

<script setup lang="ts">
import type { ClientDto } from '~/structs/dto/clients/client.dto';
import type { ChangeNameClientCommand } from '~/structs/dto/clients/change-name-client-command.dto';

const { t } = useI18n();

const props = defineProps<{
  id: string,
}>();
	
const clientsServiceProxy = useClientsServiceProxy();

// Queries
const { 
  data: changeNameGetClientByIdData, 
  pending: changeNameGetClientByIdPending, 
  error: changeNameGetClientByIdError 
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
  if (changeNameGetClientByIdData.value) {
    model.id = changeNameGetClientByIdData.value.id;
    model.firstName = changeNameGetClientByIdData.value.firstName;
    model.lastName = changeNameGetClientByIdData.value.lastName;
    model.otherNames = changeNameGetClientByIdData.value.otherNames;
  }
});

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

// PersonalInformation Options

</script>

<template>
  <ui-editor-section
    :title="t('personalInformation.title')"
    :description="t('personalInformation.description')"
  >
     <ui-input-textbox 
       v-model="model.firstName" 
       :label="t('personalInformation.firstName.label')" />
     <ui-input-textbox 
       v-model="model.lastName" 
       :label="t('personalInformation.lastName.label')" />
     <ui-input-textbox 
       v-model="model.otherNames" 
       :label="t('personalInformation.otherNames.label')" />

    <template #actions>
      <button
        type="button"
        @click="saveChangeNameClient()"
        class="rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
      >
        {{ t('personalInformation.actions.save') }}
      </button>
    </template>
    
  </ui-editor-section>
</template>