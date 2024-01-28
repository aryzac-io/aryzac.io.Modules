<script setup>
const model = defineModel({ type: Boolean });

const props = defineProps({
  label: String,
  description: String,
});
</script>

<template>
  <div class="relative flex gap-x-3">
    <div class="flex h-6 items-center">
      <input
        type="checkbox"
        v-model="model"
        class="h-4 w-4 rounded border-gray-300 text-indigo-600 focus:ring-indigo-600"
      />
    </div>
    <div class="text-sm leading-6">
      <label :for="id" class="font-medium text-gray-900">{{ label }}</label>
      <p v-if="description" class="text-gray-500">{{ description }}</p>
    </div>
  </div>
</template>
