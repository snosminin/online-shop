import axios from 'axios';
import { useRouter } from 'vue-router';

const router = useRouter();

axios.interceptors.response.use(
  (response) => response,
  (error) => {
    const status = error.response ? error.response.status : null;

    if (status === 401) {
      router.push('/login');
    } else if (status === 404) {
      router.push('/not_found');
    } else {
      alert('An error occurred. Please try again later.');
    }

    return Promise.reject(error);
  }
);
