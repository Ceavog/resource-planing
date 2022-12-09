import Loading from "components/loadingProgress";
import ModalBox from "components/modalBox";
import CssBaseline from "@mui/material/CssBaseline";
import { useRoutes } from "react-router-dom";
import routes from "router";

const App = () => {
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
