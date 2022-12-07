import { routes } from "config";
import { lazy } from "react";
import { Navigate } from "react-router-dom";

const Register = lazy(() => import("./components/register"));
const Login = lazy(() => import("./components/login"));

const GuestRouter = [
  {
    path: routes.auth.register,
    element: <Register />,
  },
  {
    path: routes.auth.login,
    element: <Login />,
  },
  { path: "*", element: <Navigate to={routes.auth.meta.basePath} replace /> },
];

export default GuestRouter;
