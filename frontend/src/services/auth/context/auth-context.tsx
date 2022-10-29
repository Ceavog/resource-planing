import React from "react";
import { AuthAPI, useAuthClient, LoginArgsType } from "../auth-client";

type AuthContextType = {
  isInitialized: boolean;
  isAuthenticated: boolean;
  init: () => Promise<void>;
  login: ({ login, password }: LoginArgsType) => Promise<void>;
  logout: () => Promise<void>;
};

type Props = {
  children: React.ReactNode;
};

const AuthContext = React.createContext<AuthContextType | null>(null);

const AuthProvider: React.FC<Props> = ({ children }) => {
  const auth = useAuthClient({
    storage: window.localStorage,
    authAPI: AuthAPI,
  });

  return (
    <AuthContext.Provider
      {...{
        children,
        value: {
          ...auth,
        },
      }}
    />
  );
};

const useAuthContext = () => React.useContext(AuthContext);

export { AuthProvider, useAuthContext };
