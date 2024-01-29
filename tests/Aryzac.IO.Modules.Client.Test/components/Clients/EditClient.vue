<i18n lang="yaml" src="@/locales/components/Clients/EditClient.i18n.yaml" />

<script setup lang="ts">
import type { ClientDto } from '~/structs/dto/clients/client.dto';
import type { TitleDto } from '~/structs/dto/titles/title.dto';
import type { InvoiceDto } from '~/structs/dto/invoices/invoice.dto';

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
const invoicesServiceProxy = useInvoicesServiceProxy();

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
const { 
  data: invoicesGetInvoicesQueryData, 
  pending: invoicesGetInvoicesQueryPending, 
  error: invoicesGetInvoicesQueryError , 
  execute: invoicesGetInvoicesQueryExecute, 
  refresh: invoicesGetInvoicesQueryRefresh, 
  status: invoicesGetInvoicesQueryStatus 
} = await invoicesServiceProxy.getInvoicesQuery();

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


// heading Options
const headingTitle = computed(() => {
  const lastName = model.lastName || '';
  const firstName = model.firstName || '';
  const mappedExpression = `${lastName}, ${firstName}`;
  return mappedExpression;
});
const headingAttributes = computed(() => [
  {
	icon: t("heading.attributes.firstnameAttribute.icon"),
	label: `${model.firstName}`,
  },
  {
	icon: t("heading.attributes.lastnameAttribute.icon"),
	label: `${model.lastName}`,
  },
]
);

const headingActions = [
  {
    label: t("heading.actions.view.label"),
    action: async () => {
      const localeRoute = useLocaleRoute();
      await navigateTo(localeRoute(`/Clients/${props.clientId}`));
    },
  },
  {
    label: t("heading.actions.invoices.label"),
    action: async () => {
      const localeRoute = useLocaleRoute();
      await navigateTo(localeRoute(`/Clients/${props.clientId}/invoices`));
    },
  },
];



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



// Invoices Options
const invoicesHeaders = [
  {
	key: 'number',
	label: t("invoices.number"),
    data: (item: InvoiceDto) => {
      const number = item.number || '';
      const mappedExpression = `${number}`;
      return mappedExpression;
    }
  },
  {
	key: 'dueDate',
	label: t("invoices.dueDate"),
    data: (item: InvoiceDto) => {
      const dueDate = item.dueDate || '';
      const mappedExpression = `${dueDate}`;
      return mappedExpression;
    }
  },
  {
	key: 'createdDate',
	label: t("invoices.createdDate"),
    data: (item: InvoiceDto) => {
      const createdDate = item.createdDate || '';
      const mappedExpression = `${createdDate}`;
      return mappedExpression;
    }
  },
];

const invoicesActions = [
];

onMounted(() => {
  editClientGetClientByIdQueryExecute();
  titleSelectGetTitlesQueryExecute();
  invoicesGetInvoicesQueryExecute();
});
</script>


<template>
  <ui-heading-page
    :title="headingTitle"
    :attributes="headingAttributes"
    :actions="headingActions"
  />
  <ui-editor-section
    :title="t('personalInformation.title')"
    :description="t('personalInformation.description')"
  >
     <ui-input-textbox 
       v-model="model.firstName" 
       :label="t('personalInformation.firstnameTextBox.label')" />
     <ui-input-textbox 
       v-model="model.lastName" 
       :label="t('personalInformation.surnameTextBox.label')" />
     <ui-input-textbox 
       v-model="model.otherNames" 
       :label="t('personalInformation.otherNamesTextBox.label')" />

    <template #actions>
      <button
        type="button"
        @click="changeNameClientCommand()"
        class="rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
      >
        {{ t('personalInformation.actions.save.label') }}
      </button>
    </template>
    
  </ui-editor-section>
  <ui-editor-section
    :title="t('salutation.title')"
    :description="t('salutation.description')"
  >
     <ui-input-select 
       v-model="model.titleId" 
       :label="t('salutation.titleSelect.label')"
       :options="titleSelectOptions"
      />

    <template #actions>
      <button
        type="button"
        @click="changeTitleClientCommand()"
        class="rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
      >
        {{ t('salutation.actions.save.label') }}
      </button>
    </template>
    
  </ui-editor-section>
  <ui-editor-section
    :title="t('subscriptions.title')"
    :description="t('subscriptions.description')"
  >
     <ui-input-checkbox 
       v-model="model.receivePromotions" 
       :label="t('subscriptions.receivePromotionsCheckBox.label')" 
       :description="t('subscriptions.receivePromotionsCheckBox.description')" />

    <template #actions>
      <button
        type="button"
        @click="changeReceivePromotionClientCommand()"
        class="rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
      >
        {{ t('subscriptions.actions.update.label') }}
      </button>
    </template>
    
  </ui-editor-section>
  <ui-editor-section
    :title="t('notes.title')"
    :description="t('notes.description')"
  >
     <ui-input-text-area 
       v-model="model.notes" 
       :label="t('notes.notes.label')" />

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
  <ui-editor-section
    :title="t('invoices.title')"
    :description="t('invoices.description')"
  >
  <ui-view-table
    :items="invoicesGetInvoicesQueryData"
    :headers="invoicesHeaders"
    :actions="invoicesActions"
    key="id"
  />
  </ui-editor-section>
</template>