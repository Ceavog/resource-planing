import FullScreenLoader from "components/placeholders/fullScreenLoader";
import Example from "modules/example";
import Order from "modules/order";
import SettingsProducts from "modules/settings/products";
import { Suspense, lazy } from "react";
import { Navigate, RouteObject } from "react-router-dom";
import Layout from "../components/layout";

const Loadable = (Component: React.ComponentType<any>) => (props: JSX.IntrinsicAttributes) =>
  (
    <Suspense fallback={<FullScreenLoader />}>
      <Component {...props} />
    </Suspense>
  );

const Register = Loadable(lazy(() => import("modules/guest/components/register")));
const Login = Loadable(lazy(() => import("modules/guest/components/login")));
const UnauthorizePage = Loadable(lazy(() => import("modules/guest/components/unauthorized")));

const authRoutes: RouteObject = {
  path: "*",
  children: [
    {
      path: "login",
      element: <Login />,
    },
    {
      path: "register",
      element: <Register />,
    },
  ],
};

const normalRoutes: RouteObject = {
  path: "*",
  element: <Layout />,
  children: [
    {
      path: "*",
      element: <Navigate to="/" replace />,
    },
    {
      index: true,
      element: <Example />,
    },
    {
      path: "settings",
      element: <SettingsProducts />,
    },
    {
      path: "order",
      element: <Order />,
    },
    // {
    //   path: "profile",
    //   element: <RequireUser allowedRoles={["user", "admin"]} />,
    //   children: [
    //     {
    //       path: "",
    //       element: <Profile />,
    //     },
    //   ],
    // },
    {
      path: "unauthorized",
      element: <UnauthorizePage />,
    },
  ],
};

const routes: RouteObject[] = [authRoutes, normalRoutes];

export default routes;
