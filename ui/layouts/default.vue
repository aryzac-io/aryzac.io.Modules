<template>
  <div>
    <layout-sidebar />

    <div class="lg:pl-72 min-h-screen">
      <layout-appbar />

      <layout-breadcrumbs />

      <main class="px-4 sm:px-6 lg:px-8 py-10">
        <!-- Your content -->
        <slot />
      </main>
    </div>
  </div>
</template>

<style>
html {
  @apply h-full bg-gray-100;
}

body {
  @apply h-full;
}
</style>
