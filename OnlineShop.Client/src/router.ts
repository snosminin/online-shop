import type { RouteRecordRaw } from 'vue-router';
import { createRouter, createWebHistory } from 'vue-router';

import Products from './views/Products.vue';
import ProductDetail from './views/ProductDetail.vue';
import Wishlist from './views/Wishlist.vue';
import Cart from './views/Cart.vue';
import Register from './views/Register.vue';
import Login from './views/Login.vue';
import AboutUs from './views/AboutUs.vue';
import ContactUs from './views/ContactUs.vue';
import NotFound from './views/NotFound.vue';

const routes: RouteRecordRaw[] = [
  {
    path: '/:productCategoryName?',
    name: 'Products',
    component: Products,
    meta: {
      layout: 'ShopLayout',
    },
  },
  {
    path: '/cart',
    name: 'Cart',
    component: Cart,
    meta: {
      layout: 'ShopLayout',
    },
  },
  {
    path: '/wishlist',
    name: 'Wishlist',
    component: Wishlist,
    meta: {
      layout: 'ShopLayout',
    },
  },
  {
    path: '/register',
    name: 'Register',
    component: Register,
    meta: {
      layout: 'EmptyLayout',
    },
  },
  {
    path: '/login',
    name: 'Login',
    component: Login,
    meta: {
      layout: 'EmptyLayout',
    },
  },
  {
    path: '/productDetail/:id',
    name: 'ProductDetail',
    component: ProductDetail,
    meta: {
      layout: 'ShopLayout',
    },
  },
  {
    path: '/aboutUs',
    name: 'AboutUs',
    component: AboutUs,
    meta: {
      layout: 'ShopLayout',
    },
  },
  {
    path: '/contactUs',
    name: 'ContactUs',
    component: ContactUs,
    meta: {
      layout: 'ShopLayout',
    },
  },
  {
    path: '/not_found',
    name: 'NotFound',
    component: NotFound,
    meta: {
      layout: 'EmptyLayout',
    },
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
