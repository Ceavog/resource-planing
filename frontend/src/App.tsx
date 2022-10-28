import AppBarNavi from "components/app-bar/app-bar";
import GuestRouter from "modules/guest/guest-router";
import MarketRouter from "modules/market/market-router";
import { QueryClient, QueryClientProvider } from "react-query";
import { useRoutes } from "react-router-dom";

const App = () => {
  const routes = useRoutes([MarketRouter, ...GuestRouter]);
  const queryClient = new QueryClient();

  return (
    <QueryClientProvider client={queryClient}>
      <AppBarNavi />
      {routes}
    </QueryClientProvider>
  );
};

export default App;
