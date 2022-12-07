import { routes } from "config";
import { lazy } from "react";
import { Navigate } from "react-router-dom";

const Market = lazy(() => import("."));

const MarketRouter = [
  { path: routes.market.menu, element: <Market /> },
  { path: "*", element: <Navigate to={routes.market.meta.basePath} replace /> },
];

export default MarketRouter;
