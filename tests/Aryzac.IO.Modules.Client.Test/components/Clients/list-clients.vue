<i18n lang="yaml" src="@/locales/components/clients/list-clients.i18n.yaml" />

<script setup lang="ts">
import type { ListClientsProps } from "~/structs/components/clients/list-clients.props";

import type { ClientDto } from "~/structs/dto/clients/client.dto";

import { useListClientsViewClientsOptions } from "~/composables/components/clients/list-clients/useListClientsViewClientsOptions";
import { useListClientsClientsTableOptions } from "~/composables/components/clients/list-clients/useListClientsClientsTableOptions";

const { t } = useI18n();

const props = defineProps<ListClientsProps>();

const clientsServiceProxy = useClientsServiceProxy();

const viewClientsOptions = await useListClientsViewClientsOptions();
const clientsTableOptions = await useListClientsClientsTableOptions();

onMounted(() => {});
</script>

<template>
  <div>
    <ui-heading-page :title="viewClientsOptions.title.value" />

    <ui-view-table
      :items="clientsTableOptions.data.value"
      :headers="clientsTableOptions.headers"
      :actions="clientsTableOptions.actions"
      key="id"
    />
  </div>
</template>
