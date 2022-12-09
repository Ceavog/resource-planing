import { createTheme } from "@mui/material/styles";
import { red } from "@mui/material/colors";
import { SxProps, Theme } from "@mui/material/styles";

export interface ISx {
  [key: string]: SxProps<Theme>;
}

const theme = createTheme({
  palette: {
    primary: {
      main: "#3b4d61",
    },
    secondary: {
      main: "#6b7b8c",
    },
    error: {
      main: red.A400,
    },
  },
});

export default theme;
