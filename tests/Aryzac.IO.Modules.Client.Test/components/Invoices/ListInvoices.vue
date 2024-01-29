<i18n lang="yaml" src="@/locales/components/Invoices/ListInvoices.i18n.yaml" />

<script setup lang="ts">
import type { InvoiceDto } from '~/structs/dto/invoices/invoice.dto';


const { t } = useI18n();

const props = defineProps<{
}>();
	
const invoicesServiceProxy = useInvoicesServiceProxy();

// Queries
const { 
  data: tableGetInvoicesQueryData, 
  pending: tableGetInvoicesQueryPending, 
  error: tableGetInvoicesQueryError , 
  execute: tableGetInvoicesQueryExecute, 
  refresh: tableGetInvoicesQueryRefresh, 
  status: tableGetInvoicesQueryStatus 
} = await invoicesServiceProxy.getInvoicesQuery();






// table Options
const tableHeaders = [
  {
	key: 'id',
	label: t("table.id"),
    data: (item: InvoiceDto) => {
      const id = item.id || '';
      const mappedExpression = `${id}`;
      return mappedExpression;
    }
  },
  {
	key: 'clientId',
	label: t("table.clientId"),
    data: (item: InvoiceDto) => {
      const clientId = item.clientId || '';
      const mappedExpression = `${clientId}`;
      return mappedExpression;
    }
  },
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
  tableGetInvoicesQueryExecute();
});
</script>


<template>
  <ui-view-table
    :items="tableGetInvoicesQueryData"
    :headers="tableHeaders"
    :actions="tableActions"
    key="id"
  />
</template>