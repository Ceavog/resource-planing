import { requestIndentity } from "api";
import { useUser } from "api/providers/user-provider";
import FullScreenLoader from "components/placeholders/fullScreenLoader";
import { useCookies } from "react-cookie";
import { useQuery } from "react-query";
import { Navigate, Outlet, useLocation } from "react-router-dom";

const RequireUser = ({ allowedRoles }: { allowedRoles: string[] }) => {
  const [cookies] = useCookies(["logged_in"]);
  const location = useLocation();
  const userContext = useUser();

  const {
    isLoading,
    isFetching,
    data: user,
  } = useQuery(["authUser"], requestIndentity, {
    retry: 1,
    onSuccess: (data) => {
      userContext?.dispatch({ type: "SET_USER", payload: data });
    },
  });

  if (isLoading || isFetching) {
    return <FullScreenLoader />;
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
