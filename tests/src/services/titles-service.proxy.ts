import { AsyncData } from 'nuxt/app';
import { ChangeCodeTitleCommand } from './../structs/dto/titles/change-code-title-command.dto';
import { ChangeDescriptionTitleCommand } from './../structs/dto/titles/change-description-title-command.dto';
import { ChangeNameTitleCommand } from './../structs/dto/titles/change-name-title-command.dto';
import { CreateTitleCommand } from './../structs/dto/titles/create-title-command.dto';
import { TitleDto } from './../structs/dto/titles/title.dto';

export class TitlesService {
  public async changeCodeTitleCommand(id: string, command: ChangeCodeTitleCommand): Promise<AsyncData<any, any>> {
    const config = useRuntimeConfig();
    let url = `${config.public.titlesServiceApiBaseUri}/api/v1/title/${id}/change-code`;
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

  public async changeDescriptionTitleCommand(id: string, command: ChangeDescriptionTitleCommand): Promise<AsyncData<any, any>> {
    const config = useRuntimeConfig();
    let url = `${config.public.titlesServiceApiBaseUri}/api/v1/title/${id}/change-description`;
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

  public async changeNameTitleCommand(id: string, command: ChangeNameTitleCommand): Promise<AsyncData<any, any>> {
    const config = useRuntimeConfig();
    let url = `${config.public.titlesServiceApiBaseUri}/api/v1/title/${id}/change-name`;
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

  public async createTitleCommand(command: CreateTitleCommand): Promise<AsyncData<string | null, any>> {
    const config = useRuntimeConfig();
    let url = `${config.public.titlesServiceApiBaseUri}/api/v1/title`;
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

  public async deleteTitleCommand(id: string): Promise<AsyncData<any, any>> {
    const config = useRuntimeConfig();
    let url = `${config.public.titlesServiceApiBaseUri}/api/v1/title/${id}`;
    return await useLazyFetch(url,
    {
    method: 'DELETE',
    headers: {
    'Content-Type': 'application/json',
    },
    }
    );
  }

  public async getTitleByIdQuery(id: string): Promise<AsyncData<TitleDto | null, any>> {
    const config = useRuntimeConfig();
    let url = `${config.public.titlesServiceApiBaseUri}/api/v1/title/${id}`;
    return await useLazyFetch<TitleDto>(url,
    {
    method: 'GET',
    headers: {
    'Content-Type': 'application/json',
    },
    }
    );
  }

  public async getTitlesQuery(): Promise<AsyncData<TitleDto[] | null, any>> {
    const config = useRuntimeConfig();
    let url = `${config.public.titlesServiceApiBaseUri}/api/v1/title`;
    return await useLazyFetch<TitleDto[]>(url,
    {
    method: 'GET',
    headers: {
    'Content-Type': 'application/json',
    },
    }
    );
  }
}