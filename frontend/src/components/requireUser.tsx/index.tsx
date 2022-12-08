import { getMeFn } from "api";
import { useStateContext } from "api/providers/api-provider";
import LoadingPlaceholder from "components/placeholders/loading-placeholder";
import { useCookies } from "react-cookie";
import { useQuery } from "react-query";
import { Navigate, Outlet, useLocation } from "react-router-dom";

const RequireUser = ({ allowedRoles }: { allowedRoles: string[] }) => {
  const [cookies] = useCookies(["logged_in"]);
  const location = useLocation();
  const stateContext = useStateContext();

  const {
    isLoading,
    isFetching,
    data: user,
  } = useQuery(["authUser"], getMeFn, {
    retry: 1,
    select: (data) => data.data.user,
    onSuccess: (data) => {
      stateContext.dispatch({ type: "SET_USER", payload: data });
    },
  });

  const loading = isLoading || isFetching;

  if (loading) {
    return <LoadingPlaceholder />;
  }

  return (cookies.logged_in || user) && allowedRoles.includes(user?.role as string) ? (
    <Outlet />
  ) : cookies.logged_in && user ? (
    <Navigate to="/unauthorized" state={{ from: location }} replace />
  ) : (
    <Navigate to="/login" state={{ from: location }} replace />
  );
};

export default RequireUser;
