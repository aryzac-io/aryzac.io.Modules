<i18n lang="yaml">
en:
  newSection:
    title: NewSection
    description: ''
    first:
      label: first
    last:
      label: last
    otherNames:
      label: OtherNames
    
</i18n>

<script setup lang="ts">
import type { ClientDto } from '~/structs/dto/clients/client.dto';
import type { ChangeNameClientCommand } from '~/structs/dto/clients/change-name-client-command.dto';

const { t } = useI18n();

const props = defineProps<{
}>();
	
const clientsServiceProxy = useClientsServiceProxy();

// Queries
const { 
  data: clientHeaderGetClientByIdData, 
  pending: clientHeaderGetClientByIdPending, 
  error: clientHeaderGetClientByIdError 
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
  if (clientHeaderGetClientByIdData.value) {
    model.id = clientHeaderGetClientByIdData.value.id;
    model.firstName = clientHeaderGetClientByIdData.value.firstName;
    model.lastName = clientHeaderGetClientByIdData.value.lastName;
    model.otherNames = clientHeaderGetClientByIdData.value.otherNames;
  }
})

// Commands
const saveChangeNameClient = async (id: string, command: ChangeNameClientCommand) => {
	const changeNameClient = await clientsServiceProxy.changeNameClient(id, command);
};

// NewSection

// first
// last
// OtherNames
</script>

<template>
  <ui-editor-section
    :title="t('newSection.title')"
    :description="t('newSection.description')"
  >
     <ui-input-textbox 
       v-model="model.first" 
       :label="t('newSection.first.label')" />
     <ui-input-textbox 
       v-model="model.last" 
       :label="t('newSection.last.label')" />
     <ui-input-textbox 
       v-model="model.otherNames" 
       :label="t('newSection.otherNames.label')" />
  </ui-editor-section>
</template>