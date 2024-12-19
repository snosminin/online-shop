<template>
  <div className="grid grid-cols-9 gap-16 my-16">
    <div
      v-for="(cart, index1) in carts"
      :key="index1"
      class="col-span-3 col-start-4 border border-gray-200 p-4 rounded"
    >
      <h4 class="text-gray-800 text-lg mb-4 font-medium uppercase">
        order summary
      </h4>
      <div
        class="space-y-2"
        v-for="(cartItem, index2) in cart?.cartItems ?? []"
        :key="index2"
      >
        <div class="flex justify-between">
          <div>
            <h5 class="text-gray-800 font-medium">
              {{ cartItem.product.name }}
            </h5>
          </div>
          <p class="text-gray-600">x{{ cartItem.quantity }}</p>
          <p class="text-gray-800 font-medium">
            ${{ cartItem.product.price * cartItem.quantity }}
          </p>
        </div>
      </div>

      <div
        class="flex justify-between border-b border-gray-200 mt-1 text-gray-800 font-medium py-3 uppercase"
      >
        <p>subtotal</p>
        <p>${{ total(cart?.cartItems ?? []) }}</p>
      </div>

      <div
        class="flex justify-between border-b border-gray-200 mt-1 text-gray-800 font-medium py-3 uppercase"
      >
        <p>shipping</p>
        <p>Free</p>
      </div>

      <div
        class="flex justify-between text-gray-800 font-medium py-3 uppercase"
      >
        <p class="font-semibold">Total</p>
        <p>${{ total(cart?.cartItems ?? []) }}</p>
      </div>

      <div class="flex items-center mb-4 mt-2">
        <input
          type="checkbox"
          name="agreement"
          id="agreement"
          class="text-primary focus:ring-0 rounded-sm cursor-pointer w-3 h-3"
        />
        <label for="agreement" class="text-gray-600 ml-3 cursor-pointer text-sm"
          >I agree to the
          <a href="#" class="text-primary">terms & conditions</a></label
        >
      </div>

      <a
        href="#"
        class="mt-8 block mx-28 py-3 px-4 text-center text-white bg-primary border border-primary rounded-md hover:bg-transparent hover:text-primary transition font-medium"
        >Place order</a
      >
    </div>
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue';
import { useRoute } from 'vue-router';
import { useCartStore } from '../store/useCartStore';
import { sumBy } from 'lodash';
import { Cart, CartItem } from '../dto/Cart';

const route = useRoute();
const cartStore = useCartStore();
const carts = ref<Cart[]>();
const total = (cartItems: CartItem[]) =>
  sumBy(cartItems, (x) => x.quantity * x.product.price);

onMounted(async () => {
  await cartStore.loadAllByUserId(1);
  carts.value = cartStore.getCarts;
});
</script>
