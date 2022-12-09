import { useCookies } from "react-cookie";
import React from "react";
import { useStateContext } from "api/providers/api-provider";
import { useQuery } from "react-query";
import { requestIndentity } from "api";
import LoadingPlaceholder from "components/placeholders/loading-placeholder";

type AuthMiddlewareProps = {
  children: React.ReactElement;
};

const AuthMiddleware: React.FC<AuthMiddlewareProps> = ({ children }) => {
  const [cookies] = useCookies(["logged_in"]);
  const stateContext = useStateContext();

  const query = useQuery(["authUser"], () => requestIndentity(), {
    enabled: !!cookies.logged_in,
    select: (data) => data.data.user,
    onSuccess: (data) => {
      stateContext.dispatch({ type: "SET_USER", payload: data });
    },
  });

  if (query.isLoading && cookies.logged_in) {
    return <LoadingPlaceholder />;
  }

  return children;
};

export default AuthMiddleware;
