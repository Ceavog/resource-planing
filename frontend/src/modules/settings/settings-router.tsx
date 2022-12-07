import { routes } from "config";
import { lazy } from "react";
import { Navigate } from "react-router-dom";

const SettingsProducts = lazy(() => import("./products/settings-products"));

const SettingsRouter = [
  { path: routes.settings.products, element: <SettingsProducts /> },
  { path: "*", element: <Navigate to={routes.settings.meta.basePath} replace /> },
];

export default SettingsRouter;
