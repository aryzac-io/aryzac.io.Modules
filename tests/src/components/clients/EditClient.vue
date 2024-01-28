<i18n lang="yaml" src="./EditClient.i18n.yaml" />

<script setup lang="ts">
import type { ClientDto } from '~/structs/dto/clients/client.dto';
import type { TitleDto } from '~/structs/dto/titles/title.dto';

import type { ChangeNameClientCommand } from '~/structs/dto/clients/change-name-client-command.dto';
import type { ChangeTitleClientCommand } from '~/structs/dto/clients/change-title-client-command.dto';
import type { ChangeReceivePromotionClientCommand } from '~/structs/dto/clients/change-receive-promotion-client-command.dto';
import type { ChangeNoteClientCommand } from '~/structs/dto/clients/change-note-client-command.dto';

const { t } = useI18n();

const props = defineProps<{
  clientId: string,
}>();
	
const clientsServiceProxy = useClientsServiceProxy();
const titlesServiceProxy = useTitlesServiceProxy();

// Queries
const { 
  data: editClientGetClientByIdQueryData, 
  pending: editClientGetClientByIdQueryPending, 
  error: editClientGetClientByIdQueryError , 
  execute: editClientGetClientByIdQueryExecute, 
  refresh: editClientGetClientByIdQueryRefresh, 
  status: editClientGetClientByIdQueryStatus 
} = await clientsServiceProxy.getClientByIdQuery(props.clientId);
const { 
  data: titleSelectGetTitlesQueryData, 
  pending: titleSelectGetTitlesQueryPending, 
  error: titleSelectGetTitlesQueryError , 
  execute: titleSelectGetTitlesQueryExecute, 
  refresh: titleSelectGetTitlesQueryRefresh, 
  status: titleSelectGetTitlesQueryStatus 
} = await titlesServiceProxy.getTitlesQuery();

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

// Commands
const changeNameClientCommand = async () => {

  const command: ChangeNameClientCommand = {
    id: model.id,
    firstName: model.firstName,
    lastName: model.lastName,
    otherNames: model.otherNames,
  };

  const id = props.clientId;
          
	const changeNameClientCommand = await clientsServiceProxy.changeNameClientCommand(id, command);
};
const changeTitleClientCommand = async () => {

  const command: ChangeTitleClientCommand = {
    id: model.id,
    titleId: model.titleId,
  };

  const id = props.clientId;
          
	const changeTitleClientCommand = await clientsServiceProxy.changeTitleClientCommand(id, command);
};
const changeReceivePromotionClientCommand = async () => {

  const command: ChangeReceivePromotionClientCommand = {
    id: model.id,
    receivePromotions: model.receivePromotions,
  };

  const id = props.clientId;
          
	const changeReceivePromotionClientCommand = await clientsServiceProxy.changeReceivePromotionClientCommand(id, command);
};
const changeNoteClientCommand = async () => {

  const command: ChangeNoteClientCommand = {
    id: model.id,
    notes: model.notes,
  };

  const id = props.clientId;
          
	const changeNoteClientCommand = await clientsServiceProxy.changeNoteClientCommand(id, command);
};


// NewLabel Options
const newLabelLabel = computed(() => {
  const lastName = model.lastName || '';
  const firstName = model.firstName || '';
  const mappedExpression = `${lastName}, ${firstName}`;
  return mappedExpression;
});

// TitleSelect Options
const titleSelectOptions = computed(() => {
  const options: { value: string; label: string }[] = [];
  if (titleSelectGetTitlesQueryData.value) {
    titleSelectGetTitlesQueryData.value.forEach((item: TitleDto) => {
      const name = item.name || '';
      const code = item.code || '';
      const mappedExpression = `${name} (${code})`;

      options.push({
        value: item.id,
        label: mappedExpression,
      });
    });
  }
  return options;
});



onMounted(() => {
  editClientGetClientByIdQueryExecute();
  titleSelectGetTitlesQueryExecute();
});
</script>

<template>
  <ui-editor-section
    :title="t('personalInformation.title')"
    :description="t('personalInformation.description')"
  >

    <template #actions>
      <button
        type="button"
        @click="changeNameClientCommand()"
        class="rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
      >
        {{ t('personalInformation.actions.save.label') }}
      </button>
    </template>
    
     <ui-input-label 
       v-model="newLabelLabel" 
       :label="t('personalInformation.newLabel.label')" />
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
  <ui-editor-section
    :title="t('salutation.title')"
    :description="t('salutation.description')"
  >

    <template #actions>
      <button
        type="button"
        @click="changeTitleClientCommand()"
        class="rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
      >
        {{ t('salutation.actions.save.label') }}
      </button>
    </template>
    
     <ui-input-select 
       v-model="model.titleId" 
       :label="t('salutation.titleSelect.label')"
       :options="titleSelectOptions"
      />
  </ui-editor-section>
  <ui-editor-section
    :title="t('promotions.title')"
    :description="t('promotions.description')"
  >
     <ui-input-checkbox 
       v-model="model.receivePromotions" 
       :label="t('promotions.newCheckbox.label')" 
       :description="t('promotions.newCheckbox.description')" />

    <template #actions>
      <button
        type="button"
        @click="changeReceivePromotionClientCommand()"
        class="rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
      >
        {{ t('promotions.actions.save.label') }}
      </button>
    </template>
    
  </ui-editor-section>
  <ui-editor-section
    :title="t('notes.title')"
    :description="t('notes.description')"
  >
     <ui-input-text-area 
       v-model="model.notes" 
       :label="t('notes.newTextArea.label')" />

    <template #actions>
      <button
        type="button"
        @click="changeNoteClientCommand()"
        class="rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
      >
        {{ t('notes.actions.save.label') }}
      </button>
    </template>
    
  </ui-editor-section>
</template>