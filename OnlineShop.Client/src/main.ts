import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import './assets/main.css';

import { createPinia } from 'pinia';
import ShopLayout from './shop-components/ShopLayout.vue';
import Products from './views/Products.vue';
import ProductItem from './views/ProductItem.vue';
import ProductDetail from './views/ProductDetail.vue';
import Wishlist from './views/Wishlist.vue';
import Cart from './views/Cart.vue';
import HeartFill from './shop-components/HeartFill.vue';
import ShoppingBagFill from './shop-components/ShoppingBagFill.vue';
import Register from './views/Register.vue';
import Login from './views/Login.vue';
import EmptyLayout from './shop-components/EmptyLayout.vue';
import AboutUs from './views/AboutUs.vue';
import ContactUs from './views/ContactUs.vue';
import setupInterceptors from './store/interceptor';
import NotFound from './views/NotFound.vue';

setupInterceptors(router);
const app = createApp(App);

app.component('ShopLayout', ShopLayout);
app.component('EmptyLayout', EmptyLayout);
app.component('Products', Products);
app.component('ProductItem', ProductItem);
app.component('ProductDetail', ProductDetail);
app.component('Wishlist', Wishlist);
app.component('Cart', Cart);
app.component('HeartFill', HeartFill);
app.component('ShoppingBagFill', ShoppingBagFill);
app.component('Register', Register);
app.component('Login', Login);
app.component('AboutUs', AboutUs);
app.component('ContactUs', ContactUs);
app.component('NotFound', NotFound);

app.use(createPinia());
app.use(router);

app.mount('#app');
