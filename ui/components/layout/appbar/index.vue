<script setup lang="ts">
import {
    Menu,
    MenuButton,
    MenuItem,
    MenuItems,
} from "@headlessui/vue";

const userNavigation = [
    { name: "Your profile", href: "#" },
    { name: "Sign out", href: "#" },
];

const { openSidebar } = useSidebar();
</script>

<template>
    <div
         class="sticky top-0 z-40 flex items-center h-16 px-4 bg-white border-b border-gray-200 shadow-sm shrink-0 gap-x-4 sm:gap-x-6 sm:px-6 lg:px-8">
        <button type="button"
                class="-m-2.5 p-2.5 text-gray-700 lg:hidden"
                @click="openSidebar">
            <span class="sr-only">Open sidebar</span>
            <Icon name="heroicons:bars-3"
                  class="w-6 h-6"
                  aria-hidden="true" />
        </button>

        <!-- Separator -->
        <div class="w-px h-6 bg-gray-200 lg:hidden"
             aria-hidden="true" />

        <div class="flex self-stretch flex-1 gap-x-4 lg:gap-x-6">
            <form class="relative flex flex-1"
                  action="#"
                  method="GET">
                <label for="search-field"
                       class="sr-only">Search</label>
                <Icon name="heroicons:magnifying-glass-20-solid"
                      class="absolute inset-y-0 left-0 w-5 h-full text-gray-400 pointer-events-none"
                      aria-hidden="true" />
                <input id="search-field"
                       class="block w-full h-full py-0 pl-8 pr-0 text-gray-900 border-0 placeholder:text-gray-400 focus:ring-0 sm:text-sm"
                       placeholder="Search..."
                       type="search"
                       name="search" />
            </form>
            <div class="flex items-center gap-x-4 lg:gap-x-6">
                <button type="button"
                        class="-m-2.5 p-2.5 text-gray-400 hover:text-gray-500">
                    <span class="sr-only">View notifications</span>
                    <Icon name="heroicons:bell"
                          class="w-6 h-6"
                          aria-hidden="true" />
                </button>

                <!-- Separator -->
                <div class="hidden lg:block lg:h-6 lg:w-px lg:bg-gray-200"
                     aria-hidden="true" />

                <!-- Profile dropdown -->
                <Menu as="div"
                      class="relative">
                    <MenuButton class="-m-1.5 flex items-center p-1.5">
                        <span class="sr-only">Open user menu</span>
                        <img class="w-8 h-8 rounded-full bg-gray-50"
                             src="https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80"
                             alt="" />
                        <span class="hidden lg:flex lg:items-center">
                            <span class="ml-4 text-sm font-semibold leading-6 text-gray-900"
                                  aria-hidden="true">Tom Cook</span>
                            <Icon name="heroicons:chevron-down-20-solid"
                                  class="w-5 h-5 ml-2 text-gray-400"
                                  aria-hidden="true" />
                        </span>
                    </MenuButton>
                    <transition enter-active-class="transition duration-100 ease-out"
                                enter-from-class="transform scale-95 opacity-0"
                                enter-to-class="transform scale-100 opacity-100"
                                leave-active-class="transition duration-75 ease-in"
                                leave-from-class="transform scale-100 opacity-100"
                                leave-to-class="transform scale-95 opacity-0">
                        <MenuItems
                                   class="absolute right-0 z-10 mt-2.5 w-32 origin-top-right rounded-md bg-white py-2 shadow-lg ring-1 ring-gray-900/5 focus:outline-none">
                            <MenuItem v-for="item in userNavigation"
                                      :key="item.name"
                                      v-slot="{ active }">
                            <a :href="item.href"
                               :class="[
                                       active ? 'bg-gray-50' : '',
                                       'block px-3 py-1 text-sm leading-6 text-gray-900',
                                   ]">{{ item.name }}</a>
                            </MenuItem>
                        </MenuItems>
                    </transition>
                </Menu>
            </div>
        </div>
    </div>
</template>