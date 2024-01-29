import { InvoicesService } from "@/services/invoices-service.proxy";

export const useInvoicesServiceProxy = () => {

  const invoicesServices = new InvoicesService();

  return { 
    changeDueDateInvoiceCommand : invoicesServices.changeDueDateInvoiceCommand,
    createInvoiceCommand : invoicesServices.createInvoiceCommand,
    deleteInvoiceCommand : invoicesServices.deleteInvoiceCommand,
    getInvoiceByIdQuery : invoicesServices.getInvoiceByIdQuery,
    getInvoicesQuery : invoicesServices.getInvoicesQuery,
    };
}