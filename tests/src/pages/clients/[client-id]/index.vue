<script setup lang="ts">
const route = useRoute();

const clientId = route.params.clientId;
</script>

<template>
  <div>
    <clients-edit-client :client-id="clientId" />
  </div>
</template>
