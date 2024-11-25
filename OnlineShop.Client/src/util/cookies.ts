import { useCookies } from 'vue3-cookies';

const { cookies } = useCookies();

const key = 'token';

export const setCookies = (value: string) => cookies.set(key, value);
export const emptyCookies = () => cookies.remove(key);
export const getCookies = () => cookies.get(key);
export const isAuthorized = () => !!cookies.get(key);
