<template>
  <div class="grid grid-cols-7 gap-6">
    <div class="col-span-3 col-start-3">
      <div
        v-for="(item, index) in wishlistStore.getWishlists"
        :key="index"
        class="flex items-center justify-between border my-4 gap-6 p-4 border-gray-200 rounded"
      >
        <div class="w-28">
          <img
            src="../assets/images/products/product1.png"
            alt="product 1"
            class="w-full"
          />
        </div>
        <div class="w-1/3">
          <h2 class="text-gray-800 text-xl font-medium uppercase">
            {{ item.product.name }}
          </h2>
          <p class="text-gray-500 text-sm">
            Availability: <span class="text-green-600">In Stock</span>
          </p>
        </div>
        <div class="text-primary text-lg font-semibold">
          {{ item.product.price }}
        </div>
        <a
          href="#"
          class="px-6 py-2 text-center text-sm text-white bg-primary border border-primary rounded hover:bg-transparent hover:text-primary transition uppercase font-roboto font-medium"
          >add to cart</a
        >
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue';
import { Product } from '../dto/Product';
import { useRoute } from 'vue-router';
import { useWishlistStore } from '../store/useWishlistStore';

const route = useRoute();
const wishlistStore = useWishlistStore();
const product = ref<Product>();

onMounted(async () => {
  await wishlistStore.loadAll();
});
</script>
