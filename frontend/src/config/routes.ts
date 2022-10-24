// import { lazy } from "react";
// const MarketRouter = lazy(() => import("modules/market/market-router"));

export const backendEndpoints = {
  login: "/LoginUser",
  refreshToken: "/RefreshToken",
  register: "http://localhost:8000/RegisterUser",
};

const routes = {
  auth: {
    login: "/login",
    meta: {
      basePath: "/login",
      routerComponent: null,
    },
  },
  market: {
    menu: "/market",
    order: "/order",
    meta: {
      basePath: "/market",
      routerComponent: null,
    },
  },
};

export default routes;
