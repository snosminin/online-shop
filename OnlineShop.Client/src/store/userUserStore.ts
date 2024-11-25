import { defineStore } from 'pinia';
import axios from 'axios';
import { authConfig, config, source } from '../util/config';
import { User } from '../model/User';
import { Login } from '../model/Login';
import { Token } from '../model/Token';
import { setCookies } from '../util/cookies';

export const useUserStore = defineStore('userStore', {
  actions: {
    async registerUser(user: User): Promise<User | null | undefined> {
      try {
        const { data } = await axios.post(
          `${source}/register`,
          JSON.stringify(user),
          config,
        );
        return data;
      } catch (error) {
        console.error(error);
      }
    },
    async login(login: Login): Promise<Token | null | undefined> {
      try {
        const { data } = await axios.post<Token>(
          `${source}/login`,
          JSON.stringify(login),
          config,
        );
        setCookies(data.token);
        return data;
      } catch (error) {
        console.error(error);
      }
    },
    async isLoggedIn(): Promise<boolean | null | undefined> {
      try {
        const { data } = await axios.get<boolean>(
          `${source}/is_logged_in`,
          authConfig,
        );
        return data;
      } catch (error) {
        console.error(error);
      }
    },
  },
});
