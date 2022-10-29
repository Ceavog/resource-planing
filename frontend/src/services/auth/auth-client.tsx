import { backendEndpoints } from "config/routes";
import React from "react";
import { API } from "services/api";
import { parseJwt } from "./utils/jwt";

type APIResponse<T, E = Error> = {
  data: T | null;
  error?: E;
};

export type LoginArgsType = {
  login: string;
  password: string;
};

type LoginResponse = {
  token: string;
  refreshToken: string;
};

type RefreshTokenResponse = {
  token: string;
  refreshToken: string;
};

type RefreshTokenError = Error & {
  isExpired: boolean;
};

type AuthAPIType = {
  login: (args: LoginArgsType) => Promise<APIResponse<LoginResponse>>;
  refreshToken: (refreshToken: string) => Promise<APIResponse<RefreshTokenResponse, RefreshTokenError>>;
  identity: (token: string) => Promise<APIResponse<UserType>>;
};

export const AuthAPI: AuthAPIType = {
  login: async ({ login, password }) => {
    try {
      const response = await API.get(backendEndpoints.login.replace(":login", login).replace(":password", password));
      const { token, refreshToken } = response.data;
      return {
        data: { token, refreshToken },
      };
    } catch (error) {
      throw { data: null, error };
    }
  },
  refreshToken: async (refreshToken) => {
    try {
      delete API.defaults.headers.Authorization;

      const response = await API.post(backendEndpoints.refreshToken.replace(":token", refreshToken));

      API.defaults.headers.Authorization = `bearer ${response.data.token}`;
      return {
        data: response.data,
      };
    } catch (error) {
      throw { data: null };
    }
  },
  identity: async (token) => {
    try {
      const response = await API.get(backendEndpoints.identity, {
        headers: {
          Authorization: `bearer ${token}`,
        },
      });

      API.defaults.headers.Authorization = `bearer ${token}`;
      return { data: response.data };
    } catch (err) {
      throw { data: null, error: err };
    }
  },
};

export type UserType = {
  id: string;
  login: string;
};

export const useAuthClient = ({ storage, authAPI }: { storage: Storage; authAPI: AuthAPIType }) => {
  const [isInitialized, setIsInitialized] = React.useState<boolean>(false);
  const [isAuthenticated, setIsAuthenticated] = React.useState<boolean>(false);
  const [user, setUser] = React.useState<UserType | null>(null);
  let intervalInstance: any;

  const token = () => storage.getItem("token") || "";
  const setToken = (value: string) => {
    if (value) {
      storage.setItem("token", value);
    } else {
      storage.removeItem("token");
    }
  };

  const refreshToken = () => storage.getItem("refresh-token") || "";
  const setRefreshToken = (value: string) => {
    if (value) {
      storage.setItem("refresh-token", value);
    } else {
      storage.removeItem("refresh-token");
    }
  };

  const setTokens = (token: string, refreshToken: string) => {
    setToken(token);
    setRefreshToken(refreshToken);
  };

  const clearTokens = () => {
    setToken("");
    setRefreshToken("");
  };

  const init = async () => {
    if (refreshToken() && token()) {
      try {
        if (shouldRefreshTokens()) {
          await refreshTokens();
        }
        await identity();
        startCheckingTokens();
      } catch (ex) {
        await logout();
      }
    } else {
      await logout();
    }

    setIsInitialized(true);
  };

  const login = async ({ login, password }: LoginArgsType) => {
    const { data, error } = await authAPI.login({ login, password });

    if (error) {
      throw error;
    }

    setIsAuthenticated(true);
    //Not sure about these
    setTokens(data?.token || "", data?.refreshToken || "");

    identity();
    startCheckingTokens();
  };

  const logout = async () => {
    setIsAuthenticated(false);
    setUser(null);
    clearTokens();
    stopCheckingTokens();
  };

  const shouldRefreshTokens = () => {
    const currentTimeInSeconds = Date.now() / 1000;
    const tokenObject = parseJwt(token()).payload;
    const remainingTimeSeconds = tokenObject.exp - currentTimeInSeconds;

    return remainingTimeSeconds <= 10;
  };

  const refreshTokens = async () => {
    if (refreshToken) {
      const { data, error } = await authAPI.refreshToken(refreshToken());

      if (error) {
        if (error.isExpired) {
          logout();
        }
        throw error;
      }

      setTokens(data?.token || "", data?.refreshToken || "");
      startCheckingTokens();
    }
  };

  const startCheckingTokens = () => {
    stopCheckingTokens();

    intervalInstance = setInterval(async () => {
      if (shouldRefreshTokens()) {
        await refreshTokens();
      }
    }, 5000);
  };

  const stopCheckingTokens = () => {
    if (intervalInstance) {
      clearInterval(intervalInstance);
      intervalInstance = null;
    }
  };

  const identity = async () => {
    const { data, error } = await AuthAPI.identity(token());

    if (error) {
      throw error;
    }
    //handle

    setIsAuthenticated(true);
    setUser(data);
  };

  return { init, login, logout, isAuthenticated, isInitialized, user };
};
