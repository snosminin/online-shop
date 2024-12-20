import { Product } from './Product';
import { User } from './User';

export type Wishlist = {
  id: number;
  product: Product;
  user: User;
};
