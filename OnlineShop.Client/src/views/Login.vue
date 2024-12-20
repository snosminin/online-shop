<template>
  <div class="contain py-16">
    <div class="max-w-lg mx-auto shadow px-6 py-7 rounded overflow-hidden">
      <h2 class="text-2xl uppercase font-medium mb-1">Login</h2>
      <p class="text-gray-600 mb-6 text-sm">welcome back customer</p>
      <Form @submit="onSubmit" :validation-schema="schema" v-slot="{ errors }">
        <div class="space-y-2">
          <div>
            <label for="email" class="text-gray-600 mb-2 block"
              >User name</label
            >
            <Field
              v-model="modelValue.Username"
              type="text"
              name="Username"
              class="block w-full border border-gray-300 px-4 py-3 text-gray-600 text-sm rounded focus:ring-0 focus:border-primary placeholder-gray-400"
              placeholder="youremail.@domain.com"
            />
            <p class="text-xs text-red-500 flex items-center mt-2">
              {{ errors.Username }}
            </p>
          </div>
          <div>
            <label for="password" class="text-gray-600 mb-2 block"
              >Password</label
            >
            <Field
              v-model="modelValue.Password"
              type="password"
              name="Password"
              class="block w-full border border-gray-300 px-4 py-3 text-gray-600 text-sm rounded focus:ring-0 focus:border-primary placeholder-gray-400"
              placeholder="*******"
            />
            <p class="text-xs text-red-500 flex items-center mt-2">
              {{ errors.Password }}
            </p>
          </div>
        </div>
        <div class="mt-4">
          <button
            type="submit"
            class="block w-full py-2 text-center text-white bg-primary border border-primary rounded hover:bg-transparent hover:text-primary transition uppercase font-roboto font-medium"
          >
            Login
          </button>
        </div>
      </Form>

      <p class="mt-4 text-center text-gray-600">
        Don't have account?
        <RouterLink
          :to="{
            name: 'Register',
          }"
          class="text-primary"
          >Register now
        </RouterLink>
      </p>
    </div>
  </div>
</template>

<script setup lang="ts">
import { useUserStore } from '../store/userUserStore';
import { Login } from '../dto/Login';
import router from '../router';
import { object, string } from 'yup';
import { Field, Form } from 'vee-validate';
import { isAuthorized } from '../util/cookies';

const userStore = useUserStore();
const onSubmit = async () => {
  await userStore.login(modelValue);
  if (isAuthorized()) {
    await router.push('/');
    router.go(0);
  }
};

const schema = object().shape({
  Password: string().required('Password is required').default(''),
  Username: string().required('User name is required').default(''),
});

const modelValue: Login = { Username: '', Password: '' };
</script>
