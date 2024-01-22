<i18n lang="yaml">
en:
  newHeading:
    title: NewHeading
    attributes:
      newHeadingAttributeLabel: NewHeadingAttribute
  tableSection:
    title: tableSection
    description: ""
    newTable:
      firstName: FirstName
      lastName: LastName
      otherNames: OtherNames
</i18n>

<script setup lang="ts">
import type { ClientDto } from "~/structs/dto/clients/client.dto";

const { t } = useI18n();

const props = defineProps<{}>();

const clientsServiceProxy = useClientsServiceProxy();

// Query
const {
  data: getClientsData,
  pending: getClientsPending,
  error: getClientsError,
} = await clientsServiceProxy.getClients();

const newHeadingAttributes = computed(() => [
  {
    icon: "",
    label: t("newHeading.attributes.newHeadingAttributeLabel"),
  },
]);

const newHeadingActions = computed(() => [
  {
    label: "Create Invoice",
    icon: "heroicons:plus",
    function: async () => {
      await navigateTo(`/clients/${props.clientId}/invoices/create`);
    },
  },
]);

const newTableHeaders = [
  {
    key: "firstName",
    label: t("tableSection.newTable.firstName"),
  },
  {
    key: "lastName",
    label: t("tableSection.newTable.lastName"),
  },
  {
    key: "otherNames",
    label: t("tableSection.newTable.otherNames"),
  },
];
</script>

<template>
  <ui-heading-page
    :title="t('newHeading.title')"
    :attributes="newHeadingAttributes"
    :actions="newHeadingActions"
  />
  <ui-editor-section
    :title="t('tableSection.title')"
    :description="t('tableSection.description')"
  >
    <ui-view-table
      :items="getClientsData"
      :headers="newTableHeaders"
      key="id"
    />
  </ui-editor-section>
</template>
