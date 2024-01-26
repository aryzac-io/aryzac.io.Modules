<i18n lang="yaml">
en:
  personal Information:
    title: Personal Information
    description: This information will be displayed publicly so be careful what you share.
    firstName:
      label: FirstName
    lastName:
      label: LastName
    otherNames:
      label: OtherNames
    
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
  data: change-NameGetClientByIdData, 
  pending: change-NameGetClientByIdPending, 
  error: change-NameGetClientByIdError 
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
  if (change-NameGetClientByIdData.value) {
    model.id = change-NameGetClientByIdData.value.id;
    model.firstName = change-NameGetClientByIdData.value.firstName;
    model.lastName = change-NameGetClientByIdData.value.lastName;
    model.otherNames = change-NameGetClientByIdData.value.otherNames;
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

// Personal Information Options

</script>

<template>
  <ui-editor-section
    :title="t('personal Information.title')"
    :description="t('personal Information.description')"
  >
     <ui-input-textbox 
       v-model="model.firstName" 
       :label="t('personal Information.firstName.label')" />
     <ui-input-textbox 
       v-model="model.lastName" 
       :label="t('personal Information.lastName.label')" />
     <ui-input-textbox 
       v-model="model.otherNames" 
       :label="t('personal Information.otherNames.label')" />

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