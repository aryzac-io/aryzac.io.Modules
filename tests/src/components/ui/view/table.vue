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
        <th scope="col" class="relative py-3.5 pl-3 pr-4 sm:pr-6">
          <span class="sr-only">Edit</span>
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
            {{ item[header.key] }}
          </template>
        </td>
        <td
          class="relative whitespace-nowrap py-4 pl-3 pr-4 text-right text-sm font-medium sm:pr-6"
        >
          <nuxt-link
            :to="`/clients/${item.id}`"
            class="text-indigo-600 hover:text-indigo-900"
          >
            Edit<span class="sr-only">, {{ getKey(item, index) }}</span>
          </nuxt-link>
        </td>
      </tr>
    </tbody>
  </table>
</template>
