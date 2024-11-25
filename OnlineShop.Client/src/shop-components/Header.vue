<template>
  <header class="py-4 shadow-sm bg-white">
    <div class="container flex items-center justify-between">
      <RouterLink :to="{ name: 'Products' }"
        ><img src="../assets/images/logo.png" alt="Logo" class="w-64"
      /></RouterLink>
      <CartHeader v-if="props.cart"></CartHeader>
    </div>
  </header>
</template>

<script setup lang="ts">
import { onMounted } from 'vue';
import CartHeader from './CartHeader.vue';

const props = defineProps(['cart']);

onMounted(async () => {});
</script>
