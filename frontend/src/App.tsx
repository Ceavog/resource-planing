import Navi from "components/navi";
import Loading from "components/loadingProgress";
import ModalBox from "components/modalBox";
// import GuestRouter from "modules/guest/guest-router";
import MarketRouter from "modules/orders/orders-router";
import SettingsRouter from "modules/settings/settings-router";
import { Suspense } from "react";
import { useRoutes } from "react-router-dom";

const App = () => {
  // const guestRoutes = useRoutes(GuestRouter);
  const authorizedRoutes = useRoutes([...MarketRouter, ...SettingsRouter]);

  return (
    <Suspense>
      <Navi />
      <Loading />
      {authorizedRoutes}
      <ModalBox />
    </Suspense>
  );
};

export default App;
