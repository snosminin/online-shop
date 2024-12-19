<template>
  <div class="container grid grid-cols-5 gap-6 pt-4 pb-16 items-start">
    <div class="col-span-3 col-start-2">
      <div class="flex items-center mb-4">
        <select
          v-model="selectedSort"
          class="w-44 text-sm text-gray-600 py-3 px-4 border-gray-300 shadow-sm rounded focus:ring-primary focus:border-primary"
        >
          <option :value="SortType.Default">Default sorting</option>
          <option :value="SortType.PriceLowToHigh">Price low to high</option>
          <option :value="SortType.PriceHighToLow">Price high to low</option>
          <option :value="SortType.Latest">Latest product</option>
        </select>
      </div>

      <div class="grid md:grid-cols-3 grid-cols-2 gap-6">
        <ProductItem
          v-for="(item, index) in sortAndFilter(productStore.getProducts)"
          :key="index"
          :modelValue="item"
        ></ProductItem>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue';
import { useProductStore } from '../store/useProductStore';
import { Product } from '../dto/Product';
import _ from 'lodash';
import { useRoute } from 'vue-router';

enum SortType {
  Default = 'default',
  PriceLowToHigh = 'price-low-to-high',
  PriceHighToLow = 'price-high-to-low',
  Latest = 'Latest',
}

const productStore = useProductStore();
const route = useRoute();

const selectedSort = ref<string>('default');
const getSort = () => {
  switch (selectedSort.value) {
    case SortType.Default:
      return { iteratees: (x: Product) => x.name, orders: 'asc' };
    case SortType.PriceLowToHigh:
      return { iteratees: (x: Product) => x.price, orders: 'asc' };
    case SortType.PriceHighToLow:
      return { iteratees: (x: Product) => x.price, orders: 'desc' };
    case SortType.Latest:
      return { iteratees: (x: Product) => x.name, orders: 'asc' };
    default:
      return { iteratees: (x: Product) => x.name, orders: 'asc' };
  }
};
const sortAndFilter = (products: Product[]) =>
  _.orderBy(
    _.filter(
      products,
      (x) =>
        !route.params.productCategory ||
        x.productCategory.name == route.params.productCategory
    ),
    getSort()
  );

onMounted(async () => {
  const products = await productStore.loadAll();
});
</script>
