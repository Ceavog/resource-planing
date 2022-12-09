import axios from "axios";
import { config } from "config";
import { backendEndpoints } from "config/routes";
import { QueryClient } from "react-query";
import { GenericResponse, ILoginResponse, ILoginVars, IUserResponse } from "./types";

export const queryClient = new QueryClient({
  defaultOptions: {
    queries: {
      refetchOnWindowFocus: false,
      retry: 1,
      staleTime: 5 * 1000,
    },
  },
});

const API = axios.create({
  baseURL: config.backendUrl,
  withCredentials: true,
});

API.defaults.headers.common["Content-Type"] = "application/json";

export const refreshAccessTokenFn = async () => {
  const response = await API.get<ILoginResponse>(backendEndpoints.refreshToken);
  return response.data;
};

API.interceptors.response.use(
  (response) => {
    return response;
  },
  async (error) => {
    const originalConfig = error.config;
    originalConfig!.headers = { ...originalConfig!.headers };

    const errMessage = error.response.statusText as string;
    if (errMessage.includes("Unauthorized") && !originalConfig._retry) {
      originalConfig._retry = true;
      await refreshAccessTokenFn();
      return API(originalConfig);
    }
    return Promise.reject(error);
  },
);

export const requestRegister = async (user: ILoginVars) => {
  const response = await API.post<GenericResponse>(
    backendEndpoints.registerUser.replace(":login", user.login).replace(":password", user.password),
  );
  return response.data;
};

export const requestLogin = async (user: ILoginVars) => {
  const response = await API.post<ILoginResponse>(backendEndpoints.login, user);
  return response.data;
};

export const requestIndentity = async () => {
  const response = await API.get<IUserResponse>(backendEndpoints.identity);
  return response.data;
};

export default API;
