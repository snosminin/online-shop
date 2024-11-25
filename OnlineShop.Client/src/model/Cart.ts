import { Product } from './Product';
import { User } from './User';

export type Cart = {
  id: number;
  user: User;
  cartItems: CartItem[];
};

export type CartItem = {
  id: number;
  product: Product;
  quantity: number;
};
