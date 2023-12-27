<script setup lang="ts">
import clients from "~/data/clients.json";

const route = useRoute();

const client = clients.find((m) => m.id === route.params.clientid);

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
    label: "Edit",
    icon: "heroicons:pencil",
    function: async () => {
      await navigateTo(`/clients/${route.params.clientid}/edit`);
    },
  },
  {
    label: "Create Invoice",
    icon: "heroicons:plus",
    function: async () => {
      await navigateTo(`/clients/${route.params.clientid}/invoices/create`);
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
    <ui-input-label :body="clientName" label="Name" />
    <ui-input-label :body="client.firstName" label="First Name" />
    <ui-input-label :body="client.lastName" label="Last Name" />
  </ui-editor-section>
  <ui-editor-section
    title="Contact Information"
    description="Email address and mobile number."
  >
    <ui-input-label :body="client.emailAddress" label="Email Address" />
    <ui-input-label :body="client.mobileNumber" label="Mobile Number" />
  </ui-editor-section>
  <ui-editor-section
    title="Invoices"
    description="Invoices created for this client."
    :padding="false"
  >
    <invoices-table :client-id="route.params.clientid" />
  </ui-editor-section>
</template>
