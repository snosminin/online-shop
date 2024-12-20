import { defineStore } from 'pinia';
import axios from 'axios';
import { ProductCategory } from '../dto/ProductCategory';
import { orderBy } from 'lodash';
import { authConfig, source } from '../util/config';

export interface RootState {
  productCategories: ProductCategory[];
}

export const useProductCategoryStore = defineStore('productCategoryStore', {
  state: () =>
    ({
      productCategories: [],
    } as RootState),
  getters: {
    getProductCategories: (state) => {
      return state.productCategories;
    },
  },

  actions: {
    async loadAll(): Promise<ProductCategory[] | undefined> {
      try {
        const { data } = await axios.get<ProductCategory[]>(
          `${source}/productCategory`,
          authConfig
        );
        this.productCategories = orderBy(data, (x) => x.id, 'asc');
        return data;
      } catch (error) {
        console.error(error);
      }
    },

    async add(
      item: ProductCategory | undefined
    ): Promise<ProductCategory | void> {
      if (!item) return console.error('Empty product category');
      try {
        if (!item.id) {
          const { data } = await axios.post<ProductCategory>(
            `${source}/productCategory`,
            item
          );
          this.getProductCategories.push(data);
          return data;
        }
      } catch (error) {
        console.error(error);
      }
    },

    async save(
      item: ProductCategory | undefined
    ): Promise<ProductCategory | void> {
      if (!item) return console.error('Empty product category');
      if (!item.id) return console.error('Empty product category id');
      try {
        const { data } = await axios.put<ProductCategory>(
          `${source}/productCategory/${item.id}`,
          item
        );
        const index = this.getProductCategories.findIndex(
          (x) => x.id === data.id
        );
        this.getProductCategories.splice(index, 1, item);
        return data;
      } catch (error) {
        console.error(error);
      }
    },

    async remove(id: number): Promise<ProductCategory | void> {
      if (!id) return console.error('Empty product category');
      try {
        const { data } = await axios.delete<ProductCategory>(
          `${source}/productCategory/${id}`
        );
        const index = this.getProductCategories.findIndex(
          (x) => x.id === data.id
        );
        this.getProductCategories.splice(index, 1);

        return data;
      } catch (error) {
        console.error(error);
      }
    },
  },
});
