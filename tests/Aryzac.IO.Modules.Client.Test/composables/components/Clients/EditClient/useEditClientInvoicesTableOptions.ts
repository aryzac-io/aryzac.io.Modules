import type { ComposerTranslation } from "@nuxtjs/i18n/dist/runtime/composables";

import type { InvoiceDto } from '~/structs/dto/invoices/invoice.dto';


export const useEditClientInvoicesTableOptions = async (t: ComposerTranslation) => {


const invoicesServiceProxy = useInvoicesServiceProxy();



// Queries
const { 
  data,
  pending,
  error,
  execute,
  refresh,
  status
} = await invoicesServiceProxy.getInvoicesByClientIdQuery(props.clientId);






const headers = [
  {
    key: 'number',
    label: t("invoicesTable.number"),
    data: (item: InvoiceDto) => {
      const number = item.number || '';
      const mappedExpression = `${number}`;
      return mappedExpression;
    }
  },
  {
    key: 'createdDate',
    label: t("invoicesTable.createdDate"),
    data: (item: InvoiceDto) => {
      const createdDate = item.createdDate || '';
      const mappedExpression = `${createdDate}`;
      return mappedExpression;
    }
  },
  {
    key: 'dueDate',
    label: t("invoicesTable.dueDate"),
    data: (item: InvoiceDto) => {
      const dueDate = item.dueDate || '';
      const mappedExpression = `${dueDate}`;
      return mappedExpression;
    }
  },
];




return {
	headers,
	data,
	pending,
	error,
	execute,
	refresh,
	status,
};

}
