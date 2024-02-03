<i18n lang="yaml" src="@/locales/components/Clients/ListClients.i18n.yaml" />

<script setup lang="ts">
import type { ListClientsProps } from "~/structs/components/clients/list-clients.props";

const { t } = useI18n();

const props = defineProps<ListClientsProps>();

onMounted(() => {});
</script>

<template>
  <div></div>
</template>
