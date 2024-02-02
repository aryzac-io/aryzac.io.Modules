import type { ComposerTranslation } from "@nuxtjs/i18n/dist/runtime/composables";

import type { InvoiceDto } from '~/structs/dto/invoices/invoice.dto';


export const useViewInvoicesTableOptions = (t: ComposerTranslation) => {


const invoicesServiceProxy = useInvoicesServiceProxy();



// ADD CODE HERE


const headers = [
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




}