import { AsyncData } from 'nuxt/app';
import { ChangeNameClientCommand } from './../structs/dto/clients/change-name-client-command.dto';
import { ChangeNoteClientCommand } from './../structs/dto/clients/change-note-client-command.dto';
import { ChangeReceivePromotionClientCommand } from './../structs/dto/clients/change-receive-promotion-client-command.dto';
import { ChangeTitleClientCommand } from './../structs/dto/clients/change-title-client-command.dto';
import { CreateClientCommand } from './../structs/dto/clients/create-client-command.dto';
import { ClientDto } from './../structs/dto/clients/client.dto';

export class ClientsService {
  public async changeNameClientCommand(id: string, command: ChangeNameClientCommand): Promise<AsyncData<any, any>> {
    const config = useRuntimeConfig();
    let url = `${config.public.clientsServiceApiBaseUri}/api/v1/client/${id}/change-name`;
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

  public async changeNoteClientCommand(id: string, command: ChangeNoteClientCommand): Promise<AsyncData<any, any>> {
    const config = useRuntimeConfig();
    let url = `${config.public.clientsServiceApiBaseUri}/api/v1/client/${id}/change-note`;
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

  public async changeReceivePromotionClientCommand(id: string, command: ChangeReceivePromotionClientCommand): Promise<AsyncData<any, any>> {
    const config = useRuntimeConfig();
    let url = `${config.public.clientsServiceApiBaseUri}/api/v1/client/${id}/change-receive-promotion`;
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

  public async changeTitleClientCommand(id: string, command: ChangeTitleClientCommand): Promise<AsyncData<any, any>> {
    const config = useRuntimeConfig();
    let url = `${config.public.clientsServiceApiBaseUri}/api/v1/client/${id}/change-title`;
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

  public async createClientCommand(command: CreateClientCommand): Promise<AsyncData<string | null, any>> {
    const config = useRuntimeConfig();
    let url = `${config.public.clientsServiceApiBaseUri}/api/v1/client`;
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

  public async deleteClientCommand(id: string): Promise<AsyncData<any, any>> {
    const config = useRuntimeConfig();
    let url = `${config.public.clientsServiceApiBaseUri}/api/v1/client/${id}`;
    return await useLazyFetch(url,
    {
    method: 'DELETE',
    headers: {
    'Content-Type': 'application/json',
    },
    }
    );
  }

  public async getClientByIdQuery(id: string): Promise<AsyncData<ClientDto | null, any>> {
    const config = useRuntimeConfig();
    let url = `${config.public.clientsServiceApiBaseUri}/api/v1/client/${id}`;
    return await useLazyFetch<ClientDto>(url,
    {
    method: 'GET',
    headers: {
    'Content-Type': 'application/json',
    },
    }
    );
  }

  public async getClientsQuery(): Promise<AsyncData<ClientDto[] | null, any>> {
    const config = useRuntimeConfig();
    let url = `${config.public.clientsServiceApiBaseUri}/api/v1/client`;
    return await useLazyFetch<ClientDto[]>(url,
    {
    method: 'GET',
    headers: {
    'Content-Type': 'application/json',
    },
    }
    );
  }
}