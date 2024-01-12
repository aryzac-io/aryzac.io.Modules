<script setup>
import { ref, defineProps, defineEmits } from 'vue';

const emit = defineEmits(["create"]);

const titleValue = ref('');         // Binding for the title input
const descriptionValue = ref('');  // Binding for the description textarea

function emitCreate() {
  emit("create", {
    title: titleValue.value,
    description: descriptionValue.value
  });

  titleValue.value = '';
  descriptionValue.value = '';
}

const props = defineProps({
  showTitle: {
    type: Boolean,
    default: false,
  },
  titlePlaceholder: {
    type: String,
    default: 'Title',
  },
  descriptionPlaceholder: {
    type: String,
    default: 'Write a description...',
  },
  createButtonText: {
    type: String,
    default: 'Create',
  },
  colSpan: {
    type: [Number, String],
    default: 3,
  },
  rows: {
    type: [Number, String],
    default: 4,
  },
});

function autoGrow(event) {
  event.target.style.height = 'auto';
  event.target.style.height = (event.target.scrollHeight) + 'px';
}
</script>

<template>
  <!-- Wrap in a flex container -->
  <div
       class="flex flex-col rounded-lg border border-gray-300 shadow-sm focus-within:border-indigo-500 focus-within:ring-1 focus-within:ring-indigo-500">
    <!-- Main content -->
    <div class="flex-grow overflow-hidden">
      <div v-if="showTitle">
        <label for="title"
               class="sr-only">Title</label>
        <input v-model="titleValue"
               type="text"
               name="title"
               id="title"
               class="block w-full border-0 pt-2.5 text-lg font-medium
        placeholder:text-gray-400 focus:ring-0"
               :placeholder="titlePlaceholder" />
      </div>
      <label for="description"
             class="sr-only">Description</label>
      <textarea v-model="descriptionValue"
                :class="{ 'pt-2.5': !showTitle }"
                rows="2"
                name="description"
                id="description"
                v-on:input="autoGrow($event)"
                class="block w-full resize-none border-0 py-0 text-gray-900 placeholder:text-gray-400 focus:ring-0 sm:text-sm sm:leading-6"
                :placeholder="descriptionPlaceholder"></textarea>
      <!-- Spacer element to match the height of the toolbar -->
      <div aria-hidden="true"
           v-if="$slots.attributes">
        <div class="py-2">
          <div class="h-9"></div>
        </div>
        <div class="h-px"></div>
        <div class="py-2">
          <div class="py-px">
            <div class="h-9"></div>
          </div>
        </div>
        <!-- Slot for additional attributes like assignee, due date, tags, etc. -->
        <div class="flex flex-nowrap justify-end space-x-2 px-2 py-2 sm:px-3">
          <slot name="attributes"></slot>
        </div>
      </div>
    </div>
    <!-- Footer (Actions) -->
    <div
         :class="[$slots.actions ? 'justify-between' : 'justify-end', 'border-t border-gray-200 px-2 py-2 sm:px-3 flex items-center space-x-3']">
      <!-- Slot for actionable controls like attaching a file or other actions -->
      <slot name="actions"></slot>
      <div class="flex-shrink-0">
        <button @click="emitCreate"
                type="button"
                class="inline-flex items-center rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600">{{
                  createButtonText }}</button>
      </div>
    </div>
  </div>
</template>
