import { Product } from './Product';

export type ProductAttachment = {
  id: number;
  name: string;
  data: string;
  product: Product;
};
