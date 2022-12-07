import { LinearProgress } from "@mui/material";
import { useContext } from "react";
import { DisplayLoadingContext } from "./providers/loading-provider";

const Loading: React.FC = () => {
  const { open } = useContext(DisplayLoadingContext);

  return <>{open && <LinearProgress />}</>;
};

export default Loading;
