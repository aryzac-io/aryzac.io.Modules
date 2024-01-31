<i18n lang="yaml" src="@/locales/components/Clients/ViewClient.i18n.yaml" />

<script setup lang="ts">


import type { ClientDto } from '~/structs/dto/clients/client.dto';


const { t } = useI18n();


const props = defineProps<{
  clientId: string,
}>();
	

const clientsServiceProxy = useClientsServiceProxy();

// Queries
const { 
  data: viewClientGetClientByIdQueryData, 
  pending: viewClientGetClientByIdQueryPending, 
  error: viewClientGetClientByIdQueryError , 
  execute: viewClientGetClientByIdQueryExecute, 
  refresh: viewClientGetClientByIdQueryRefresh, 
  status: viewClientGetClientByIdQueryStatus 
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
  if (viewClientGetClientByIdQueryData.value) {
    model.id = viewClientGetClientByIdQueryData.value.id;
    model.firstName = viewClientGetClientByIdQueryData.value.firstName;
    model.lastName = viewClientGetClientByIdQueryData.value.lastName;
    model.otherNames = viewClientGetClientByIdQueryData.value.otherNames;
    model.titleId = viewClientGetClientByIdQueryData.value.titleId;
    model.receivePromotions = viewClientGetClientByIdQueryData.value.receivePromotions;
    model.notes = viewClientGetClientByIdQueryData.value.notes;
  }
});




// heading Options
const headingTitle = computed(() => {
  const lastName = model.lastName || '';
  const firstName = model.firstName || '';
  const otherNames = model.otherNames || '';
  const mappedExpression = `${lastName}, ${firstName} ${otherNames}`;
  return mappedExpression;
});
const headingAttributes = computed(() => [
]
);

const headingActions = [
  {
    label: t("heading.actions.edit.label"),
    action: async () => {
      const localeRoute = useLocaleRoute();
      await navigateTo(localeRoute(`/Clients/${props.clientId}/edit`));
    },
  },
];


// FirstName Options
const firstNameLabel = computed(() => {
  const firstName = model.firstName || '';
  const mappedExpression = `${firstName}`;
  return mappedExpression;
});
// LastName Options
const lastNameLabel = computed(() => {
  const lastName = model.lastName || '';
  const mappedExpression = `${lastName}`;
  return mappedExpression;
});
// OtherNames Options
const otherNamesLabel = computed(() => {
  const otherNames = model.otherNames || '';
  const mappedExpression = `${otherNames}`;
  return mappedExpression;
});

// ReceivePromotions Options
const receivePromotionsLabel = computed(() => {
  const receivePromotions = model.receivePromotions || '';
  const mappedExpression = `${receivePromotions}`;
  return mappedExpression;
});

// Notes Options
const notesLabel = computed(() => {
  const notes = model.notes || '';
  const mappedExpression = `${notes}`;
  return mappedExpression;
});

onMounted(() => {
  viewClientGetClientByIdQueryExecute();
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
     <ui-input-label 
       v-model="firstNameLabel" 
       :label="t('personalInformation.firstName.label')" />
     <ui-input-label 
       v-model="lastNameLabel" 
       :label="t('personalInformation.lastName.label')" />
     <ui-input-label 
       v-model="otherNamesLabel" 
       :label="t('personalInformation.otherNames.label')" />
  </ui-editor-section>
  <ui-editor-section
    :title="t('subscriptions.title')"
    :description="t('subscriptions.description')"
  >
     <ui-input-label 
       v-model="receivePromotionsLabel" 
       :label="t('subscriptions.receivePromotions.label')" />
  </ui-editor-section>
  <ui-editor-section
    :title="t('internalNotes.title')"
    :description="t('internalNotes.description')"
  >
     <ui-input-label 
       v-model="notesLabel" 
       :label="t('internalNotes.notes.label')" />
  </ui-editor-section>
</template>