<i18n lang="yaml" src="@/locales/components/Clients/ViewInvoices.i18n.yaml" />

<script setup lang="ts">


import type { InvoiceDto } from '~/structs/dto/invoices/invoice.dto';


const { t } = useI18n();


const props = defineProps<{
  clientId: string,
}>();
	

const invoicesServiceProxy = useInvoicesServiceProxy();

// Queries
const { 
  data: tableGetInvoicesByClientIdQueryData, 
  pending: tableGetInvoicesByClientIdQueryPending, 
  error: tableGetInvoicesByClientIdQueryError , 
  execute: tableGetInvoicesByClientIdQueryExecute, 
  refresh: tableGetInvoicesByClientIdQueryRefresh, 
  status: tableGetInvoicesByClientIdQueryStatus 
} = await invoicesServiceProxy.getInvoicesByClientIdQuery(props.clientId);






// table Options
const tableHeaders = [
  {
	key: 'number',
	label: t("table.number"),
    data: (item: InvoiceDto) => {
      const number = item.number || '';
      const mappedExpression = `${number}`;
      return mappedExpression;
    }
  },
  {
	key: 'createdDate',
	label: t("table.createdDate"),
    data: (item: InvoiceDto) => {
      const createdDate = item.createdDate || '';
      const mappedExpression = `${createdDate}`;
      return mappedExpression;
    }
  },
  {
	key: 'dueDate',
	label: t("table.dueDate"),
    data: (item: InvoiceDto) => {
      const dueDate = item.dueDate || '';
      const mappedExpression = `${dueDate}`;
      return mappedExpression;
    }
  },
];

const tableActions = [
];


onMounted(() => {
  tableGetInvoicesByClientIdQueryExecute();
});
</script>


<template>
  <ui-view-table
    :items="tableGetInvoicesByClientIdQueryData"
    :headers="tableHeaders"
    :actions="tableActions"
    key="id"
  />
</template>