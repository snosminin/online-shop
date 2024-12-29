<template>
  <div>
    <Header :cart="false" />
    <Navbar :menu="false" />
    <slot />
    <Copyright />
  </div>
</template>

<script setup lang="ts">
import Navbar from './Navbar.vue';
import Header from './Header.vue';
import Copyright from './Copyright.vue';
</script>
