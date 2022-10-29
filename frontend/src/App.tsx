import AppBarNavi from "components/app-bar/app-bar";
import GuestRouter from "modules/guest/guest-router";
import MarketRouter from "modules/market/market-router";
import SettingsRouter from "modules/settings/settings-router";
import { Suspense, useEffect } from "react";
import { useRoutes } from "react-router-dom";
import { useAuthContext } from "services/auth";

const App = () => {
  const guestRoutes = useRoutes(GuestRouter);
  const authorizedRoutes = useRoutes([...MarketRouter, ...SettingsRouter]);
  const auth = useAuthContext();

  useEffect(() => {
    if (!auth?.isInitialized) {
      auth?.init();
    } else if (!auth.isAuthenticated) {
      auth?.logout();
    }
  }, [auth]);

  if (!auth?.isInitialized) {
    return <div>Loading...</div>;
  }

  if (!auth?.isAuthenticated) {
    return <Suspense>{guestRoutes}</Suspense>;
  }

  return (
    <Suspense>
      <AppBarNavi />
      {authorizedRoutes}
    </Suspense>
  );
};

export default App;
