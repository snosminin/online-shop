import axios from 'axios';
import { Router } from 'vue-router';

const setupInterceptors = (router: Router) => {
  axios.interceptors.response.use(
    (response) => {
      console.log('response', response);
      return response;
    },
    (error) => {
      const status = error.response ? error.response.status : null;
      console.log('error', error, router);
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
};

export default setupInterceptors;
