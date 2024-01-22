import type { AsyncData } from "nuxt/app";
import type { ChangeNameClientCommand } from "~/structs/dto/clients/change-name-client-command.dto";
import type { ClientDto } from "~/structs/dto/clients/client.dto";
import type { CreateClientCommand } from "~/structs/dto/clients/create-client-command.dto";

export class ClientsService {
  public async changeNameClient(
    id: string,
    command: ChangeNameClientCommand
  ): Promise<AsyncData<any, any>> {
    const config = useRuntimeConfig();
    let url = `${config.public.clientsServiceApiBaseUri}/api/v1/client/${id}/change-name`;
    return await useFetch(url, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(command),
    });
  }

  public async createClient(
    newDTOField: string,
    command: CreateClientCommand
  ): Promise<AsyncData<string | null, any>> {
    const config = useRuntimeConfig();
    let url = `${config.public.clientsServiceApiBaseUri}/api/v1/client`;
    return await useFetch<string>(url, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        newDTOField: newDTOField ?? "abc",
      },
      body: JSON.stringify(command),
    });
  }

  public async deleteClient(id: string): Promise<AsyncData<any, any>> {
    const config = useRuntimeConfig();
    let url = `${config.public.clientsServiceApiBaseUri}/api/v1/client/${id}`;
    return await useFetch(url, {
      method: "DELETE",
      headers: {
        "Content-Type": "application/json",
      },
    });
  }

  public async getClientById(
    id: string
  ): Promise<AsyncData<ClientDto | null, any>> {
    const config = useRuntimeConfig();
    let url = `${config.public.clientsServiceApiBaseUri}/api/v1/client/${id}`;
    return await useFetch<ClientDto>(url, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
    });
  }

  public async getClients(): Promise<AsyncData<ClientDto[] | null, any>> {
    const config = useRuntimeConfig();
    let url = `${config.public.clientsServiceApiBaseUri}/api/v1/client`;
    return await useFetch<ClientDto[]>(url, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
    });
  }
}
