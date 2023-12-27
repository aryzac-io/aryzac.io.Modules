<script setup lang="ts">
import clients from "~/data/clients.json";

const pending = ref(false);

const viewsConfig = [
  {
    name: "table",
    label: "Table",
    icon: "heroicons:table-cells",
  },
];

const actionsConfig = [
  {
    label: "Add New",
    icon: "heroicons:plus",
    function: async () => {
      await navigateTo(`/clients/create`);
    },
  },
];
</script>

<template>
  <ui-view
    :config="viewsConfig"
    :actions="actionsConfig"
    :items="clients"
    :loading="pending"
    title="Clients"
    description="A list of all the clients including their name, email and mobile number."
  >
    <template #table="{ items }">
      <ui-view-table
        :items="items"
        :headers="[
          {
            key: 'firstName',
            label: 'First Name',
            class:
              'py-3.5 pl-4 pr-3 text-left text-sm font-semibold text-gray-900 sm:pl-6',
          },
          { key: 'lastName', label: 'LastName' },
          { key: 'emailAddress', label: 'Email Address' },
          { key: 'mobileNumber', label: 'Mobile Number' },
        ]"
        key="id"
        base-link="/clients"
      />
    </template>
  </ui-view>
</template>
