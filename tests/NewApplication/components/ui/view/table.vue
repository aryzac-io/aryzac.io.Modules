<script setup>
// Props definition
const props = defineProps({
  items: {
    type: Array,
    default: () => [],
  },
  headers: {
    type: Array,
    default: () => [],
  },
  key: {
    type: [String, Function],
    default: "id",
  },
  actions: {
    type: Array,
    default: () => [],
    validator: (items) => items.every((item) => typeof item === "object"),
  },
});

const getKey = (item, index) => {
  if (typeof props.key.value === "function") {
    return props.key.value(item);
  } else if (
    typeof props.key.value === "string" &&
    item[props.key.value] !== undefined
  ) {
    return item[props.key.value];
  } else {
    console.warn(
      `A valid key could not be determined for the table item at index ${index}. Falling back to index. Consider providing a valid key prop.`
    );
    return index;
  }
};
</script>

<template>
  <table class="min-w-full divide-y divide-gray-300">
    <thead class="bg-gray-50">
      <tr>
        <th
          v-for="header in headers"
          :key="header.key"
          class="py-3.5 px-3 text-left text-sm font-semibold text-gray-900"
        >
          {{ header.label }}
        </th>
        <th
          scope="col"
          class="py-3.5 pl-3 pr-4 sm:pr-6 text-right whitespace-nowrap w-auto"
        >
          <span class="sr-only">Actions</span>
        </th>
      </tr>
    </thead>
    <tbody class="divide-y divide-gray-200 bg-white">
      <tr v-for="(item, index) in items" :key="getKey(item, index)">
        <td
          v-for="header in headers"
          :key="header.key"
          class="whitespace-nowrap px-3 py-4 text-sm text-gray-500"
        >
          <template v-if="header.template">
            <slot :name="header.template" :item="item" />
          </template>
          <template v-else>
            {{ header.data(item) }}
          </template>
        </td>
        <td class="py-4 pl-3 pr-4 sm:pr-6 text-right whitespace-nowrap w-auto">
          <div class="flex justify-end gap-x-2">
            <button
              v-for="(action, actionId) in actions"
              :key="actionId"
              type="button"
              class="text-indigo-600 hover:text-indigo-900"
              @click="action.action(item)"
            >
              <span class="sr-only">{{ action.label }}</span>
              <icon
                v-if="action.icon"
                :name="action.icon"
                class="h-6 w-6 shrink-0"
              />
              <span v-else>{{ action.label }}</span>
            </button>
          </div>
        </td>
      </tr>
    </tbody>
  </table>
</template>
