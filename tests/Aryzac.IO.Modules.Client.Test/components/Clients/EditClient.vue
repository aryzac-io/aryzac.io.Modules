<i18n lang="yaml" src="@/locales/components/Clients/EditClient.i18n.yaml" />

<script setup lang="ts">


import type { EditClientProps } from '~/structs/components/clients/edit-client.props';

import type { ClientDto } from '~/structs/dto/clients/client.dto';

import type { ChangeNameClientCommand } from '~/structs/dto/clients/change-name-client-command.dto';

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
    label: t("heading.actions.save.label"),
    action: async (item: EditClient) => {
      await changeNameClientCommand();
    },
  },
];


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
