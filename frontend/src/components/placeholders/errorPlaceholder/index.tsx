import * as React from "react";
import { Box, Typography } from "@mui/material";
import { Error } from "@mui/icons-material";
import { placeholderStyles } from "../loadingPlaceholder";
import Placeholder from "../placeholder";

type Props = {
  error?: any;
  message?: string;
  fullscreen?: boolean;
  fontSize?: number;
};

const ErrorPlaceholder: React.FC<Props> = ({ error, message = "Sorry, something went wrong", fullscreen = false, fontSize }) => {
  const renderPlaceholder = () => (
    <Placeholder
      image={<Error color="error" fontSize={"large"} />}
      message={
        <Typography color="error" style={{ fontSize: fontSize ? fontSize : undefined }}>
          {typeof error === "string" ? error : message}
        </Typography>
      }
    />
  );

  return fullscreen ? <Box sx={placeholderStyles.fullscreen}>{renderPlaceholder()}</Box> : renderPlaceholder();
};

export default ErrorPlaceholder;
