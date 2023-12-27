<template>
  <div>
    <div v-if="$slots.header" class="px-4 py-5 sm:px-6">
      <slot name="header" />
    </div>
    <div>
      <slot />
    </div>
    <div v-if="$slots.footer" class="px-4 py-4 sm:px-6">
      <slot name="footer" />
    </div>
  </div>
</template>
