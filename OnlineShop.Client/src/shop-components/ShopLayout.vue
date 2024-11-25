<template>
  <div class="font-poppins">
    <Header :cart="true" />
    <Navbar :menu="true" />
    <slot />
    <Footer />
    <Copyright />
  </div>
</template>

<script setup lang="ts">
import Navbar from './Navbar.vue';
import Header from './Header.vue';
import Footer from './Footer.vue';
import Copyright from './Copyright.vue';
</script>
