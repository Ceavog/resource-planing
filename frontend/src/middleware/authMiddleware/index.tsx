import { useCookies } from "react-cookie";
import React from "react";
import { useUser } from "api/providers/user-provider";
import { useQuery } from "react-query";
import { requestIndentity } from "api";
import FullScreenLoader from "components/placeholders/fullScreenLoader";

type AuthMiddlewareProps = {
  children: React.ReactElement;
};

const AuthMiddleware: React.FC<AuthMiddlewareProps> = ({ children }) => {
  const [cookies] = useCookies(["logged_in"]);
  const userContext = useUser();

  const query = useQuery(["authUser"], () => requestIndentity(), {
    enabled: !!cookies.logged_in,
    onSuccess: (data) => {
      userContext?.dispatch({ type: "SET_USER", payload: data });
    },
  });

  if (query.isLoading && cookies.logged_in) {
    return <FullScreenLoader />;
  }

  return children;
};

export default AuthMiddleware;
