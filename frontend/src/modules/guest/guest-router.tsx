import { routes } from "config";
import { lazy } from "react";
import { Navigate } from "react-router-dom";

const RegisterView = lazy(() => import("./views/register"));
const LoginView = lazy(() => import("./views/login"));

const GuestRouter = [
  {
    path: routes.auth.register,
    element: <RegisterView />,
  },
  {
    path: routes.auth.login,
    element: <LoginView />,
  },
  { path: "*", element: <Navigate to={routes.auth.meta.basePath} replace /> },
];

export default GuestRouter;
