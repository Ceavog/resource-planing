export const backendEndpoints = {
  login: "/LoginUser?login=:login&password=:password",
  refreshToken: "/RefreshToken?token=:token",
  registerUser: "/RegisterUser?login=:login&password=:password",
  identity: "/Identity",
};

const routes = {
  auth: {
    login: "/login",
    register: "/register",
    meta: {
      basePath: "/login",
    },
  },
  market: {
    menu: "/market",
    meta: {
      basePath: "/market",
    },
  },
};

export default routes;
