<script setup>
const props = defineProps({
  modelValue: [String, Number],
  label: String,
  name: String,
  id: String,
});

const emit = defineEmits(["update:modelValue"]);
</script>

<template>
  <div class="flex items-center gap-x-3">
    <input
      :id="id"
      :name="name"
      type="radio"
      v-bind:value="modelValue"
      v-on:input="updateValue($event)"
      class="h-4 w-4 border-gray-300 text-indigo-600 focus:ring-indigo-600"
    />
    <label
      :for="id"
      class="block text-sm font-medium leading-6 text-gray-900"
      >{{ label }}</label
    >
  </div>
</template>
