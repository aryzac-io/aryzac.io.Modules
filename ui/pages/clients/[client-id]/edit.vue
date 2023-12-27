<script setup lang="ts">
const route = useRoute();

const navigation = useNavigation();

const clientSection navigation.addSection('Client Actions');
clientSection.addLink({
  label: 'View',
  icon: 'heroicons:eye',
  function: async () => {
    await navigateTo(`/clients/${route.params.clientid}`);
  },
});
clientSection.addLink({
  label: 'Create Invoice',
  icon: 'heroicons:table-cells',
  function: async () => {
    await navigateTo(`/clients/${route.params.clientid}/invoices/create`);
  },
});

const invoiceSection = navigation.addSection('Recent Invoices');
const invoiceService = useInvoiceService();
const recentInvoices = await invoiceService.getRecentInvoices(route.params.clientid);
recentInvoices.forEach((invoice) => {
  invoiceSection.addLink({
    label: invoice.invoiceNumber,
    icon: 'heroicons:table-cells',
    function: async () => {
      await navigateTo(`/invoices/${invoice.id}`);
    },
  });
});
</script>

<template>
  <clients-edit :client-id="route.params.clientid" />
</template>
