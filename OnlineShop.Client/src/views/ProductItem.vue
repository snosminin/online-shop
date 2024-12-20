<template>
  <div class="bg-white shadow rounded overflow-hidden group">
    <div class="relative">
      <img
        src="../assets/images/products/product1.png"
        alt="product 1"
        class="w-full"
      />
      <RouterLink
        :to="{
          name: 'ProductDetail',
          params: { id: modelValue.id },
        }"
      >
        <div
          class="absolute inset-0 bg-black bg-opacity-40 flex items-center justify-center gap-2 opacity-0 group-hover:opacity-100 transition"
        ></div
      ></RouterLink>
    </div>
    <div class="pt-4 pb-3 px-4">
      <RouterLink
        :to="{
          name: 'ProductDetail',
          params: { id: modelValue.id },
        }"
      >
        <h4
          class="uppercase font-medium text-xl mb-2 text-gray-800 hover:text-primary transition"
        >
          {{ modelValue.name }}
        </h4>
      </RouterLink>
      <div class="flex items-baseline mb-1 space-x-2">
        <p class="text-xl text-primary font-semibold">
          ${{ modelValue.price - modelValue.price * modelValue.discount.value }}
        </p>
        <p class="text-sm text-gray-400 line-through">
          ${{ modelValue.price }}
        </p>
      </div>
      <div class="flex items-center">
        <div class="text-xs text-gray-500 ml-3">
          ({{ modelValue.quantity }})
        </div>
      </div>
    </div>
    <a
      href="#"
      class="block w-full py-1 text-center text-white bg-primary border border-primary rounded-b hover:bg-transparent hover:text-primary transition"
      >Add to cart</a
    >
  </div>
</template>

<script setup lang="ts">
import { PropType } from 'vue';
import { Product } from '../dto/Product';

const { modelValue = {} as Product } = defineProps({
  modelValue: Object as PropType<Product>,
});
</script>
