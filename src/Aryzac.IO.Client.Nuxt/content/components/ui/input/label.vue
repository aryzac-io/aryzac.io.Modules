<script setup>
const model = defineModel();

const props = defineProps({
  label: String,
});
</script>

<template>
  <div>
    <label class="block text-sm font-medium leading-6 text-gray-900">{{
      label
    }}</label>
    <div class="mt-2">
      <span>{{ model }}</span>
    </div>
  </div>
</template>
