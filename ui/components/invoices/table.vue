<script setup lang="ts">
import allInvoices from "~/data/invoices.json";

const props = defineProps({
  clientId: {
    type: String,
    required: true,
  },
});

const invoices = allInvoices.filter((m) => m.clientId === props.clientId);

const pending = ref(false);

const viewsConfig = [
  {
    name: "table",
    label: "Table",
    icon: "heroicons:table-cells",
  },
];

const actionsConfig = [];
</script>

<template>
  <ui-view
    :config="viewsConfig"
    :actions="actionsConfig"
    :items="invoices"
    :loading="pending"
  >
    <template #table="{ items }">
      <ui-view-table
        :items="items"
        :headers="[
          {
            key: 'number',
            label: 'Number',
            class:
              'py-3.5 pl-4 pr-3 text-left text-sm font-semibold text-gray-900 sm:pl-6',
          },
          { key: 'date', label: 'Date' },
          { key: 'amount', label: 'Amount (ZAR)', class: 'text-right' },
        ]"
        key="id"
        :base-link="`/clients/${props.clientId}/invoices`"
      />
    </template>
  </ui-view>
</template>
