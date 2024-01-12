<script setup>
const props = defineProps({
  modelValue: String,
  label: String,
  name: String,
  id: String,
  colSpan: {
    type: [Number, String],
    default: 3,
  },
  rows: {
    type: [Number, String],
    default: 4,
  },
});

const emit = defineEmits(["update:modelValue"]);

let value = ref(props.modelValue);

watchEffect(() => {
  value.value = props.modelValue;
});

function updateValue(event) {
  emit("update:modelValue", event.target.value);
  autoGrow(event);
}

// Auto-grow functionality
function autoGrow(event) {
  event.target.style.height = 'auto';
  event.target.style.height = (event.target.scrollHeight) + 'px';
}
</script>

<template>
  <div :class="['sm:col-span-' + colSpan]">
    <label :for="id"
           class="block text-sm font-medium leading-6 text-gray-900">{{ label
           }}</label>
    <div class="mt-2">
      <textarea :name="name"
                :id="id"
                :rows="rows"
                autocomplete="given-name"
                v-bind:value="modelValue"
                v-on:input="updateValue($event)"
                class="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-1 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6 resize-none overflow-hidden"></textarea>
    </div>
  </div>
</template>
