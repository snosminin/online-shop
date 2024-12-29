<template>
  <div class="contain py-16">
    <div class="max-w-lg mx-auto shadow px-6 py-7 rounded overflow-hidden">
      <h2 class="text-2xl uppercase font-medium mb-1">Login</h2>
      <p class="text-gray-600 mb-6 text-sm">welcome back customer</p>
      <Form @submit="onSubmit" :validation-schema="schema" v-slot="{ errors }">
        <div class="space-y-2">
          <div>
            <label for="email" class="input-label">User name</label>
            <Field
              v-model="modelValue.Username"
              type="text"
              name="Username"
              class="input-field"
              placeholder="youremail.@domain.com"
            />
            <p class="input-error">
              {{ errors.Username }}
            </p>
          </div>
          <div>
            <label for="password" class="input-label">Password</label>
            <Field
              v-model="modelValue.Password"
              type="password"
              name="Password"
              class="input-field"
              placeholder="*******"
            />
            <p class="input-error">
              {{ errors.Password }}
            </p>
          </div>
        </div>
        <div class="mt-4">
          <button type="submit" class="submit-button">Login</button>
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
