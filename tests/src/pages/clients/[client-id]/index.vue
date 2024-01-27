<script setup lang="ts">
const route = useRoute();

const clientId = route.params.clientid;
</script>

<template>
  <div>
    <clients-edit-client 
	    :client-id="clientId"	/>
  </div>
</template>