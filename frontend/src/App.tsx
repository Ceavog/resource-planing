import Navi from "components/navi";
import Loading from "components/loadingProgress";
import ModalBox from "components/modalBox";
import CssBaseline from "@mui/material/CssBaseline";
// import GuestRouter from "modules/guest/guest-router";
import MarketRouter from "modules/order/orders-router";
import SettingsRouter from "modules/settings/settings-router";
import { Suspense } from "react";
import { useRoutes } from "react-router-dom";
import routes from "router";

const App = () => {
  // const guestRoutes = useRoutes(GuestRouter);
  // const authorizedRoutes = useRoutes([...MarketRouter, ...SettingsRouter]);
  const content = useRoutes(routes);

  return (
    <>
      <CssBaseline />
      <Loading />
      <ModalBox />
      {content}
    </>
  );
};

export default App;
