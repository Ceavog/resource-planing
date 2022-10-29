import { routes } from "config";
import { lazy } from "react";
import { Navigate } from "react-router-dom";

const MarketView = lazy(() => import("./views/market-view"));

const MarketRouter = [
  { path: routes.market.menu, element: <MarketView /> },
  { path: "*", element: <Navigate to={routes.market.meta.basePath} replace /> },
];

export default MarketRouter;
