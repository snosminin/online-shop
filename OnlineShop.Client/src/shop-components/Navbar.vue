<template>
  <nav class="bg-gray-800">
    <div class="container flex">
      <div
        v-if="menu"
        class="px-8 py-4 bg-primary md:flex items-center cursor-pointer relative group hidden"
      >
        <span class="capitalize ml-2 text-white">Categories</span>

        <div
          class="invisible absolute w-full left-0 top-full bg-white shadow-md py-3 divide-y divide-gray-300 divide-dashed opacity-0 group-hover:opacity-100 transition duration-300 group-hover:visible"
        >
          <RouterLink
            v-for="(item, index) in store.productCategories"
            :key="index"
            :to="{
              name: 'Products',
              params: { productCategoryName: item.name },
            }"
            class="flex items-center px-3 py-3 hover:bg-gray-100 transition"
          >
            <span class="text-gray-600 text-sm">{{ item.name }}</span>
          </RouterLink>
        </div>
      </div>

      <div
        v-if="menu"
        class="flex items-center justify-between flex-grow md:pl-12 py-5"
      >
        <div class="flex items-center space-x-6 capitalize text-white">
          <RouterLink class="navbar-menu-item" :to="{ name: 'Products' }"
            >Home</RouterLink
          >

          <RouterLink class="navbar-menu-item" :to="{ name: 'AboutUs' }"
            >About us</RouterLink
          >

          <RouterLink class="navbar-menu-item" :to="{ name: 'ContactUs' }"
            >Contact us</RouterLink
          >
        </div>
      </div>

      <div
        class="flex items-end justify-end flex-grow md:pl-12 py-5 text-white"
      >
        <a v-if="menu" href="" @click="onLogout" class="navbar-menu-item"
          >Logout</a
        >
      </div>
    </div>
  </nav>
</template>

<script setup lang="ts">
import router from '../router';
import { useProductCategoryStore } from '../store/useProductCategoryStore';
import { onMounted } from 'vue';
import { emptyCookies } from '../util/cookies';

const store = useProductCategoryStore();

const { menu } = defineProps(['menu']);

const onLogout = () => {
  emptyCookies();
  router.push('/login');
};

onMounted(async () => {
  if (menu) await store.loadAll();
});
</script>
