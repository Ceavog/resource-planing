import { routes } from "config";
import { lazy } from "react";
import { Navigate } from "react-router-dom";

const SettingsView = lazy(() => import("./views/settings-view"));
const SettingsProductsView = lazy(() => import("./views/settings-products-view"));

const SettingsRouter = [
  { path: routes.settings.configurations, element: <SettingsView /> },
  { path: routes.settings.products, element: <SettingsProductsView /> },
  { path: "*", element: <Navigate to={routes.settings.meta.basePath} replace /> },
];

export default SettingsRouter;
