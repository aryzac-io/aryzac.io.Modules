<script setup>
const props = defineProps({
  modelValue: Boolean,
  label: String,
  description: String,
  name: String,
  id: String,
});

const emit = defineEmits(["update:modelValue"]);
</script>

<template>
  <div class="relative flex gap-x-3">
    <div class="flex h-6 items-center">
      <input
        :id="id"
        :name="name"
        type="checkbox"
        v-bind:value="modelValue"
        v-on:input="updateValue($event)"
        class="h-4 w-4 rounded border-gray-300 text-indigo-600 focus:ring-indigo-600"
      />
    </div>
    <div class="text-sm leading-6">
      <label :for="id" class="font-medium text-gray-900">{{ label }}</label>
      <p class="text-gray-500">{{ description }}</p>
    </div>
  </div>
</template>
