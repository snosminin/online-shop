import { getCookies } from './cookies';

export const source = 'http://localhost:8181/api';

export const config = {
  headers: {
    'Content-Type': 'application/json;charset=UTF-8',
    'Access-Control-Allow-Origin': '*',
  },
};

export const authConfig = {
  headers: {
    ...config.headers,
    Authorization: `Bearer ${getCookies()}`,
  },
};
