<i18n lang="yaml" src="@/locales/components/Clients/EditClient.i18n.yaml" />

<script setup lang="ts">


import type { EditClientProps } from '~/structs/components/clients/edit-client.props';
import type { EditClientModel } from '~/structs/components/clients/edit-client.model';

import type { ClientDto } from '~/structs/dto/clients/client.dto';


import { useEditClientHeadingOptions } from '~/composables/components//Clients/EditClient/useEditClientHeadingOptions'
import { useEditClientNewSelectOptions } from '~/composables/components//Clients/EditClient/useEditClientNewSelectOptions'

const { t } = useI18n();


const props = defineProps<EditClientProps>();


const clientsServiceProxy = useClientsServiceProxy();

const query = await clientsServiceProxy.getClientByIdQuery(props.clientId);const model = reactive<EditClientModel>({} as EditClientModel);

watchEffect(async () => {
  if (query.data.value) {
    Object.assign(model, query.data.value);
  }
});

const headingOptions = await useEditClientHeadingOptions(props, model);
const newSelectOptions = await useEditClientNewSelectOptions(props, model);

onMounted(() => {
  query.execute();
});
</script>


<template src="./EditClient.template.html" />