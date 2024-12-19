import { Discount } from './Discount';
import { ProductCategory } from './ProductCategory';

export type Product = {
  id: number;
  name: string;
  productCategory: ProductCategory;
  discount: Discount;
  description: string;
  price: number;
  quantity: number;
  sku: string;
};
