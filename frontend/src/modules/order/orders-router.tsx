import { routes } from "config";
import { lazy } from "react";
import { Navigate } from "react-router-dom";

const Orders = lazy(() => import("."));

const OrdersRouter = [
  { path: routes.orders.menu, element: <Orders /> },
  { path: "*", element: <Navigate to={routes.orders.meta.basePath} replace /> },
];

export default OrdersRouter;
