<i18n lang="yaml" src="./NewComponent.i18n.yaml" />

<script setup lang="ts">

import type { ChangeNameClientCommand } from '~/structs/dto/clients/change-name-client-command.dto';

const { t } = useI18n();

const props = defineProps<{
  newComponentParameter: boolean,
}>();
	
const clientsServiceProxy = useClientsServiceProxy();




// Commands
const saveChangeNameClientCommand = async () => {

  const command: ChangeNameClientCommand = {
    id: model.id,
    firstName: model.firstName,
    lastName: model.lastName,
    otherNames: model.otherNames,
  };

  const id: string = props.id;

	const changeNameClientCommand = await clientsServiceProxy.changeNameClientCommand(id, command);
};

</script>

<template>
</template>