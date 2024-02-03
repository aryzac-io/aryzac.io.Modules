<i18n lang="yaml" src="@/locales/components/Clients/EditClient.i18n.yaml" />

<script setup lang="ts">
import { useEditClientHeadingOptions } from "~/composables/components/Clients/EditClient/useEditClientHeadingOptions";
import type { EditClientModel } from "~/structs/components/clients/edit-client.model";
import type { EditClientProps } from "~/structs/components/clients/edit-client.props";

import type { ClientDto } from "~/structs/dto/clients/client.dto";

const { t } = useI18n();

const props = defineProps<EditClientProps>();

const clientsServiceProxy = useClientsServiceProxy();

const query = await clientsServiceProxy.getClientByIdQuery(props.clientId);

const model: EditClientModel = reactive({
  id: "",
  firstName: "",
  lastName: "",
  otherNames: "",
  titleId: "",
  receivePromotions: false,
  notes: "",
});

watchEffect(async () => {
  if (query.data.value) {
    model.id = query.data.value.id;
    model.firstName = query.data.value.firstName;
    model.lastName = query.data.value.lastName;
    model.otherNames = query.data.value.otherNames;
    model.titleId = query.data.value.titleId;
    model.receivePromotions = query.data.value.receivePromotions;
    model.notes = query.data.value.notes;
  }
});

const heading = await useEditClientHeadingOptions(props, model);

onMounted(() => {
  query.execute();
});
</script>

<template>
  <ui-heading-page :title="heading.title.value" />
</template>
