import { defineStore } from 'pinia';
import axios from 'axios';
import { authConfig, config, source } from '../util/config';
import { User } from '../dto/User';
import { Login } from '../dto/Login';
import { Token } from '../dto/Token';
import { setCookies } from '../util/cookies';
import { CreateUserResponse } from '../dto/CreateUserResponse';

export const useUserStore = defineStore('userStore', {
  actions: {
    async registerUser(user: User): Promise<boolean> {
      try {
        const { data } = await axios.post<CreateUserResponse>(
          `${source}/register`,
          JSON.stringify(user),
          config
        );
        return data.CreationSucceed;
      } catch (error) {
        console.error(error);
        return false;
      }
    },
    async login(login: Login): Promise<boolean> {
      try {
        const { data } = await axios.post<Token>(
          `${source}/login`,
          JSON.stringify(login),
          config
        );
        setCookies(data.token);
        return true;
      } catch (error) {
        console.error(error);
        return false;
      }
    },
    async isLoggedIn(): Promise<boolean> {
      try {
        const { data } = await axios.get<boolean>(
          `${source}/is_logged_in`,
          authConfig
        );
        return data;
      } catch (error) {
        console.error(error);
        return false;
      }
    },
  },
});
