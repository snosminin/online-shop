<template>
  <div class="contain py-16">
    <div class="max-w-lg mx-auto shadow px-6 py-7 rounded overflow-hidden">
      <h2 class="text-2xl uppercase font-medium mb-1">Create an account</h2>
      <p class="text-gray-600 mb-6 text-sm">Register for new customer</p>
      <Form @submit="onSubmit" :validation-schema="schema" v-slot="{ errors }">
        <div class="space-y-2">
          <div>
            <label for="Username" class="text-gray-600 mb-2 block"
              >User name</label
            >
            <Field
              name="Username"
              v-model="modelValue.Username"
              as="input"
              class="block w-full border border-gray-300 px-4 py-3 text-gray-600 text-sm rounded focus:ring-0 focus:border-primary placeholder-gray-400"
              placeholder="John Smith"
            />
            <p class="text-xs text-red-500 flex items-center mt-2">
              {{ errors.Username }}
            </p>
          </div>
          <div>
            <label for="Email" class="text-gray-600 mb-2 block"
              >Email address</label
            >
            <Field
              v-model="modelValue.Email"
              name="Email"
              as="input"
              class="block w-full border border-gray-300 px-4 py-3 text-gray-600 text-sm rounded focus:ring-0 focus:border-primary placeholder-gray-400"
              placeholder="youremail.@domain.com"
            />
            <p class="text-xs text-red-500 flex items-center mt-2">
              {{ errors.Email }}
            </p>
          </div>
          <div>
            <label for="FirstName" class="text-gray-600 mb-2 block"
              >First Name</label
            >
            <Field
              v-model="modelValue.FirstName"
              name="FirstName"
              as="input"
              class="block w-full border border-gray-300 px-4 py-3 text-gray-600 text-sm rounded focus:ring-0 focus:border-primary placeholder-gray-400"
              placeholder="John Smith"
            />
            <p class="text-xs text-red-500 flex items-center mt-2">
              {{ errors.FirstName }}
            </p>
          </div>
          <div>
            <label for="LastName" class="text-gray-600 mb-2 block"
              >Last Name</label
            >
            <Field
              v-model="modelValue.LastName"
              name="LastName"
              as="input"
              class="block w-full border border-gray-300 px-4 py-3 text-gray-600 text-sm rounded focus:ring-0 focus:border-primary placeholder-gray-400"
              placeholder="John Smith"
            />
            <p class="text-xs text-red-500 flex items-center mt-2">
              {{ errors.LastName }}
            </p>
          </div>
          <div>
            <label for="Password" class="text-gray-600 mb-2 block"
              >Password</label
            >
            <Field
              v-model="modelValue.Password"
              name="Password"
              type="password"
              class="block w-full border border-gray-300 px-4 py-3 text-gray-600 text-sm rounded focus:ring-0 focus:border-primary placeholder-gray-400"
              placeholder="*******"
            />
            <p class="text-xs text-red-500 flex items-center mt-2">
              {{ errors.Password }}
            </p>
          </div>
          <div>
            <label for="ConfirmPassword" class="text-gray-600 mb-2 block"
              >Confirm password</label
            >
            <Field
              v-model="modelValue.ConfirmPassword"
              name="ConfirmPassword"
              type="password"
              class="block w-full border border-gray-300 px-4 py-3 text-gray-600 text-sm rounded focus:ring-0 focus:border-primary placeholder-gray-400"
              placeholder="*******"
            />
            <p class="text-xs text-red-500 flex items-center mt-2">
              {{ errors.ConfirmPassword }}
            </p>
          </div>
        </div>
        <div class="mt-6">
          <div class="flex items-center">
            <input
              type="checkbox"
              v-model="modelValue.IsCheckedAgreement"
              class="text-primary focus:ring-0 rounded-sm cursor-pointer"
            />
            <label class="text-gray-600 ml-3 cursor-pointer"
              >I have read and agree to the
              <a href="#" class="text-primary">terms & conditions</a></label
            >
          </div>
          <p class="text-xs text-red-500 flex items-center mt-2">
            {{ agreementErrorMessage }}
          </p>
        </div>
        <div class="mt-4">
          <button
            type="submit"
            class="block w-full py-2 text-center text-white bg-primary border border-primary rounded hover:bg-transparent hover:text-primary transition uppercase font-roboto font-medium"
          >
            create account
          </button>
        </div>
      </Form>

      <p class="mt-4 text-center text-gray-600">
        Already have account?
        <RouterLink
          :to="{
            name: 'Login',
          }"
          class="text-primary"
          >Login now
        </RouterLink>
      </p>
    </div>
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue';
import { useUserStore } from '../store/userUserStore';
import { User } from '../model/User';
import { Field, Form, useForm } from 'vee-validate';
import { object, string } from 'yup';
import router from '../router';
import { UserForm } from '../model/UserForm';

const userStore = useUserStore();
const agreementErrorMessage = ref<string>('');

const schema = object().shape({
  Email: string()
    .required('Email is required')
    .email('This field must be email')
    .default(''),
  FirstName: string().required('First Name is required').default(''),
  LastName: string().required('Last Name is required').default(''),
  Password: string().required('Password is required').default(''),
  Username: string().required('User name is required').default(''),
  ConfirmPassword: string()
    .required('Confirm password is required')
    .default(''),
});

const onSubmit = () => {
  if (modelValue.IsCheckedAgreement)
    userStore.registerUser(modelValue).then(() => router.push('/login'));
  else agreementErrorMessage.value = 'You must agreed terms & conditions';
};

const modelValue: UserForm = {
  Email: '',
  FirstName: '',
  Id: 0,
  LastName: '',
  Password: '',
  Username: '',
  ConfirmPassword: '',
  IsCheckedAgreement: false,
};

onMounted(async () => {});
</script>
