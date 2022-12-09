import React from "react";
import { Box, CircularProgress, Typography } from "@mui/material";
import Placeholder from "../placeholder";

type Props = {
  message?: React.ReactNode;
  inline?: boolean;
  fullscreen?: boolean;
  fontSize?: number;
};

export const placeholderStyles = {
  fullscreen: {
    height: "100vh",
    width: "100%",
    display: "flex",
  },
};

const LoadingPlaceholder: React.FC<Props> = ({ message = "Loading...", inline = false, fullscreen = false, fontSize }) => {
  const renderPlaceholder = () => (
    <Placeholder
      image={<CircularProgress size={inline ? 15 : 40} />}
      message={message && <Typography style={{ fontSize: fontSize ? fontSize : undefined }}>{message}</Typography>}
    />
  );

  return fullscreen ? <Box sx={placeholderStyles.fullscreen}>{renderPlaceholder()}</Box> : renderPlaceholder();
};

export default LoadingPlaceholder;
