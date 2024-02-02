import type { ComposerTranslation } from "@nuxtjs/i18n/dist/runtime/composables";

import type { InvoiceDto } from '~/structs/dto/invoices/invoice.dto';


export const useEditClientInvoicesOptions = (t: ComposerTranslation) => {


const invoicesServiceProxy = useInvoicesServiceProxy();







const headers = [
  {
    key: 'number',
    label: t("invoices.number"),
    data: (item: InvoiceDto) => {
      const number = item.number || '';
      const mappedExpression = `${number}`;
      return mappedExpression;
    }
  },
  {
    key: 'createdDate',
    label: t("invoices.createdDate"),
    data: (item: InvoiceDto) => {
      const createdDate = item.createdDate || '';
      const mappedExpression = `${createdDate}`;
      return mappedExpression;
    }
  },
  {
    key: 'dueDate',
    label: t("invoices.dueDate"),
    data: (item: InvoiceDto) => {
      const dueDate = item.dueDate || '';
      const mappedExpression = `${dueDate}`;
      return mappedExpression;
    }
  },
];




}
