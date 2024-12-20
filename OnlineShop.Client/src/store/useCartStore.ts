import { defineStore } from 'pinia';
import axios from 'axios';
import { Cart } from '../dto/Cart';
import { authConfig, source } from '../util/config';

export interface RootState {
  carts: Cart[];
}

export const useCartStore = defineStore('cartStore', {
  state: () =>
    ({
      carts: [],
    } as RootState),
  getters: {
    getCarts: (state): Cart[] => {
      return state.carts;
    },
    getById: (state) => {
      return (id: number): Cart => state.carts.find((x) => x.id === id) as Cart;
    },
  },

  actions: {
    async loadAll(): Promise<Cart[] | undefined> {
      try {
        const { data } = await axios.get<Cart>(
          `${source}/shoppingSession`,
          authConfig
        );
        this.carts = [data];
        return [data];
      } catch (error) {
        console.error(error);
      }
    },
  },
});
