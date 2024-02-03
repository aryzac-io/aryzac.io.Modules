import { AsyncData } from 'nuxt/app';
import { ChangeDueDateInvoiceCommand } from './../structs/dto/invoices/change-due-date-invoice-command.dto';
import { CreateInvoiceCommand } from './../structs/dto/invoices/create-invoice-command.dto';
import { InvoiceDto } from './../structs/dto/invoices/invoice.dto';

export class InvoicesService {
  public async changeDueDateInvoiceCommand(id: string, command: ChangeDueDateInvoiceCommand): Promise<AsyncData<any, any>> {
    const config = useRuntimeConfig();
    let url = `${config.public.invoicesServiceApiBaseUri}/api/v1/invoice/${id}/change-due-date`;
    return await useLazyFetch(url,
    {
    method: 'PUT',
    headers: {
    'Content-Type': 'application/json',
    },
    body: JSON.stringify(command),
    }
    );
  }

  public async createInvoiceCommand(command: CreateInvoiceCommand): Promise<AsyncData<string | null, any>> {
    const config = useRuntimeConfig();
    let url = `${config.public.invoicesServiceApiBaseUri}/api/v1/invoice`;
    return await useLazyFetch<string>(url,
    {
    method: 'POST',
    headers: {
    'Content-Type': 'application/json',
    },
    body: JSON.stringify(command),
    }
    );
  }

  public async deleteInvoiceCommand(id: string): Promise<AsyncData<any, any>> {
    const config = useRuntimeConfig();
    let url = `${config.public.invoicesServiceApiBaseUri}/api/v1/invoice/${id}`;
    return await useLazyFetch(url,
    {
    method: 'DELETE',
    headers: {
    'Content-Type': 'application/json',
    },
    }
    );
  }

  public async getInvoiceByIdQuery(id: string): Promise<AsyncData<InvoiceDto | null, any>> {
    const config = useRuntimeConfig();
    let url = `${config.public.invoicesServiceApiBaseUri}/api/v1/invoice/${id}`;
    return await useLazyFetch<InvoiceDto>(url,
    {
    method: 'GET',
    headers: {
    'Content-Type': 'application/json',
    },
    }
    );
  }

  public async getInvoicesQuery(): Promise<AsyncData<InvoiceDto[] | null, any>> {
    const config = useRuntimeConfig();
    let url = `${config.public.invoicesServiceApiBaseUri}/api/v1/invoice`;
    return await useLazyFetch<InvoiceDto[]>(url,
    {
    method: 'GET',
    headers: {
    'Content-Type': 'application/json',
    },
    }
    );
  }

  public async getInvoicesByClientIdQuery(clientId: string): Promise<AsyncData<InvoiceDto[] | null, any>> {
    const config = useRuntimeConfig();
    let url = `${config.public.invoicesServiceApiBaseUri}/api/v1/invoice/by/client/${clientid}`;
    return await useLazyFetch<InvoiceDto[]>(url,
    {
    method: 'GET',
    headers: {
    'Content-Type': 'application/json',
    },
    }
    );
  }
}