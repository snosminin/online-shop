<template>
  <component :is="layout">
    <router-view />
  </component>
</template>

<script setup lang="ts">
import { computed, onMounted } from 'vue';
import { useRouter } from 'vue-router';
import { useUserStore } from './store/userUserStore';
import { isAuthorized } from './util/cookies';

useUserStore();

const router = useRouter();
const layout = computed(
  () => router.currentRoute.value.meta.layout ?? 'EmptyLayout',
);

onMounted(async () => {
  if (!isAuthorized()) router.push('/login');
});
</script>
