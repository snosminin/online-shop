import { defineStore } from 'pinia';
import axios from 'axios';
import { orderBy } from 'lodash';
import { Wishlist } from '../model/Wishlist';
import { authConfig, source } from '../util/config';

export interface RootState {
  wishlists: Wishlist[];
}

export const useWishlistStore = defineStore('wishlistStore', {
  state: () =>
    ({
      wishlists: [],
    }) as RootState,
  getters: {
    getWishlists: (state): Wishlist[] => {
      return state.wishlists;
    },
    getById: (state) => {
      return (id: number): Wishlist =>
        state.wishlists.find((x) => x.id === id) as Wishlist;
    },
  },

  actions: {
    async loadAll(): Promise<Wishlist[] | undefined> {
      try {
        const { data } = await axios.get<Wishlist[]>(
          `${source}/wishlist`,
          authConfig,
        );
        this.wishlists = orderBy(data, (x) => x.id, 'asc').map(
          (x) => x as Wishlist,
        );
        return data;
      } catch (error) {
        console.error(error);
      }
    },
  },
});
