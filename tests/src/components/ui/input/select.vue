<script setup>
const props = defineProps({
  modelValue: [String, Number],
  label: String,
  name: String,
  id: String,
  options: Array,
  colSpan: {
    type: [Number, String],
    default: 3,
  },
});

const emit = defineEmits(["update:modelValue"]);

let value = ref(props.modelValue);

watchEffect(() => {
  value.value = props.modelValue;
});

function updateValue(event) {
  emit("update:modelValue", event.target.value);
}
</script>

<template>
  <div :class="['sm:col-span-' + colSpan]">
    <label :for="id"
           class="block text-sm font-medium leading-6 text-gray-900">{{ label
           }}</label>
    <div class="mt-2">
      <select :name="name"
              :id="id"
              v-bind:value="modelValue"
              v-on:change="updateValue($event)"
              class="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:max-w-xs sm:text-sm sm:leading-6">
        <option v-for="(option, index) in options"
                :key="index"
                :value="option.value">
          {{ option.label }}
        </option>
      </select>
    </div>
  </div>
</template>
