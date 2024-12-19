import { ProductAttachment } from '../dto/ProductAttachment';
import { defineStore } from 'pinia';
import axios from 'axios';
import { orderBy } from 'lodash';
import { Product } from '../dto/Product';
import { authConfig, source } from '../util/config';

export interface RootState {
  products: Product[];
  productImages: ProductAttachment[];
}

export const useProductStore = defineStore('productStore', {
  state: () =>
    ({
      products: [],
      productImages: [],
    } as RootState),
  getters: {
    getProducts: (state): Product[] => {
      return state.products;
    },
    getById: (state) => {
      return (id: number): Product =>
        state.products.find((x) => x.id === id) as Product;
    },
    getProductImagesByProductId: (state) => {
      return (productId: number): ProductAttachment =>
        state.productImages.find(
          (x) => x.product.id === productId
        ) as ProductAttachment;
    },
  },

  actions: {
    async loadAll(): Promise<Product[] | undefined> {
      try {
        const { data } = await axios.get<Product[]>(
          `${source}/product`,
          authConfig
        );
        this.products = orderBy(data, (x) => x.id, 'asc').map(
          (x) => x as Product
        );
        return data;
      } catch (error) {
        console.error(error);
      }
    },
  },
});
