import LoadingPlaceholder from "components/placeholders/loading-placeholder";
import RequireUser from "components/requireUser.tsx";
import Order from "modules/order";
import Example from "modules/order/example";
import SettingsProducts from "modules/settings/products/settings-products";
import Profile from "modules/settings/profile";
import { Suspense, lazy } from "react";
import type { RouteObject } from "react-router-dom";
import Layout from "../components/layout";

const Loadable = (Component: React.ComponentType<any>) => (props: JSX.IntrinsicAttributes) =>
  (
    <Suspense fallback={<LoadingPlaceholder />}>
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
    {
      path: "profile",
      element: <RequireUser allowedRoles={["user", "admin"]} />,
      children: [
        {
          path: "",
          element: <Profile />,
        },
      ],
    },
    {
      path: "unauthorized",
      element: <UnauthorizePage />,
    },
  ],
};

const routes: RouteObject[] = [authRoutes, normalRoutes];

export default routes;
