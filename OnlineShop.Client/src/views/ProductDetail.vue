<template>
  <div class="container py-4 flex items-center gap-3"></div>

  <div class="container grid grid-cols-2 gap-6">
    <div>
      <img
        src="../assets/images/products/product1.png"
        alt="product"
        class="w-full"
      />
      <div class="grid grid-cols-5 gap-4 mt-4">
        <img
          src="../assets/images/products/product1.png"
          alt="product1"
          class="w-full cursor-pointer border border-primary"
        />
        <img
          src="../assets/images/products/product1.png"
          alt="product1"
          class="w-full cursor-pointer border"
        />
        <img
          src="../assets/images/products/product1.png"
          alt="product1"
          class="w-full cursor-pointer border"
        />
        <img
          src="../assets/images/products/product1.png"
          alt="product1"
          class="w-full cursor-pointer border"
        />
        <img
          src="../assets/images/products/product1.png"
          alt="product1"
          class="w-full cursor-pointer border"
        />
      </div>
    </div>

    <div>
      <h2 class="text-3xl font-medium uppercase mb-2">{{ product?.name }}</h2>

      <div class="space-y-2">
        <p class="text-gray-800 font-semibold space-x-2">
          <span>Availability: </span>
          <span class="text-green-600">In Stock</span>
        </p>
        <p class="space-x-2">
          <span class="text-gray-800 font-semibold">Brand: </span>
          <span class="text-gray-600">Apex</span>
        </p>
        <p class="space-x-2">
          <span class="text-gray-800 font-semibold">Category: </span>
          <span class="text-gray-600">{{ product?.productCategory.name }}</span>
        </p>
        <p class="space-x-2">
          <span class="text-gray-800 font-semibold">SKU: </span>
          <span class="text-gray-600">{{ product?.sku }}</span>
        </p>
      </div>
      <div class="flex items-baseline mb-1 space-x-2 font-roboto mt-4">
        <p class="text-xl text-primary font-semibold">
          ${{ discountedPrice() }}
        </p>
        <p class="text-base text-gray-400 line-through">
          ${{ product?.price }}
        </p>
      </div>

      <p class="mt-4 text-gray-600">{{ product?.description }}</p>

      <div class="mt-4">
        <h3 class="text-sm text-gray-800 uppercase mb-1">Quantity</h3>
        <div
          class="flex border border-gray-300 text-gray-600 divide-x divide-gray-300 w-max"
        >
          <div
            class="h-8 w-8 text-xl flex items-center justify-center cursor-pointer select-none"
          >
            -
          </div>
          <div class="h-8 w-8 text-base flex items-center justify-center">
            {{ product?.quantity }}
          </div>
          <div
            class="h-8 w-8 text-xl flex items-center justify-center cursor-pointer select-none"
          >
            +
          </div>
        </div>
      </div>

      <div class="mt-6 flex gap-3 border-b border-gray-200 pb-5 pt-5">
        <a
          href="#"
          class="bg-primary border border-primary text-white px-8 py-2 font-medium rounded uppercase flex items-center gap-2 hover:bg-transparent hover:text-primary transition"
        >
          Add to cart
        </a>
        <a
          href="#"
          class="border border-gray-300 text-gray-600 px-8 py-2 font-medium rounded uppercase flex items-center gap-2 hover:text-primary transition"
        >
          Wishlist
        </a>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue';
import { Product } from '../dto/Product';
import { useRoute } from 'vue-router';
import { useProductStore } from '../store/useProductStore';

const route = useRoute();
const productStore = useProductStore();
const product = ref<Product>();
const discountedPrice = () => {
  if (product.value?.price)
    return (
      product.value.price - product.value.price * product.value.discount.value
    );
};

onMounted(async () => {
  await productStore.loadAllByProductCategoryName();
  product.value = productStore.getById(+route.params.id);
});
</script>
