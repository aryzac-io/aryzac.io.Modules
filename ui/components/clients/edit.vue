<script setup lang="ts">
import clients from "~/data/clients.json";
import { defineProps } from "vue";

const props = defineProps({
  clientId: {
    type: String,
    required: true,
  },
});

const client = clients.find((m) => m.id === props.clientId);

if (!client) {
  throw new Error("Client not found");
}

const clientName = computed(() => client.lastName + ", " + client.firstName);

const attributes = computed(() => [
  {
    icon: "heroicons:envelope-20-solid",
    value: client.emailAddress,
  },
  {
    icon: "heroicons:phone-20-solid",
    value: client.mobileNumber,
  },
]);

const actions = computed(() => [
  {
    label: "Create Invoice",
    icon: "heroicons:plus",
    function: async () => {
      await navigateTo(`/clients/${props.clientId}/invoices/create`);
    },
  },
]);
</script>

<template>
  <ui-heading-page
    :title="clientName"
    :attributes="attributes"
    :actions="actions"
  />
  <ui-editor-section
    title="Personal Information"
    description="Name and personal identification information."
  >
    <ui-input-textbox v-model="client.firstName" label="First Name" />
    <ui-input-textbox v-model="client.lastName" label="Last Name" />

    <template #actions>
      <button
        type="button"
        class="inline-flex items-center gap-x-2 rounded-md bg-indigo-600 px-3.5 py-2.5 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
      >
        Save
      </button>
    </template>
  </ui-editor-section>
  <ui-editor-section
    title="Contact Information"
    description="Email address and mobile number."
  >
    <ui-input-textbox v-model="client.emailAddress" label="Email Address" />
    <ui-input-textbox v-model="client.mobileNumber" label="Mobile Number" />

    <template #actions>
      <button
        type="button"
        class="inline-flex items-center gap-x-2 rounded-md bg-indigo-600 px-3.5 py-2.5 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
      >
        Save
      </button>
    </template>
  </ui-editor-section>
  <ui-editor-section
    title="Invoices"
    description="Invoices created for this client."
    :padding="false"
  >
    <invoices-table :client-id="clientId" />
  </ui-editor-section>
</template>
