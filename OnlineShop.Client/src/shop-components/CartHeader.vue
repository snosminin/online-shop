<template>
  <div class="flex items-center space-x-4">
    <RouterLink
      :to="{ name: 'Wishlist' }"
      class="text-center text-gray-700 hover:text-primary transition relative"
    >
      <div class="text-2xl">
        <HeartFill />
      </div>
      <div class="text-xs mx-4 leading-3"></div>
      <div
        class="absolute -right-3 -top-1 w-5 h-5 rounded-full flex items-center justify-center bg-primary text-white text-xs"
      >
        {{ wishlists?.length }}
      </div>
    </RouterLink>
    <RouterLink
      :to="{ name: 'Cart' }"
      class="text-center text-gray-700 hover:text-primary transition relative"
    >
      <div class="text-2xl">
        <ShoppingBagFill />
      </div>
      <div class="text-xs mx-4 leading-3"></div>
      <div
        class="absolute -right-3 -top-1 w-5 h-5 rounded-full flex items-center justify-center bg-primary text-white text-xs"
      >
        {{ first(carts)?.cartItems.length }}
      </div>
    </RouterLink>
  </div>
</template>

<script setup lang="ts">
import { useCartStore } from '../store/useCartStore';
import { onMounted, ref } from 'vue';
import { Cart } from '../model/Cart';
import { useWishlistStore } from '../store/useWishlistStore';
import { Wishlist } from '../model/Wishlist';
import { first } from 'lodash';

const cartStore = useCartStore();
const carts = ref<Cart[]>();

const wishlistStore = useWishlistStore();
const wishlists = ref<Wishlist[]>();

onMounted(async () => {
  carts.value = await cartStore.loadAllByUserId(1);
  wishlists.value = await wishlistStore.loadAll();
});
</script>
