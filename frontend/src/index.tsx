import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";
import reportWebVitals from "./reportWebVitals";
import { ThemeProvider } from "@emotion/react";
import CssBaseline from "@mui/material/CssBaseline";
import "@fontsource/roboto/300.css";
import "@fontsource/roboto/400.css";
import "@fontsource/roboto/500.css";
import "@fontsource/roboto/700.css";
import theme from "config/theme";
import { BrowserRouter } from "react-router-dom";
import { AuthProvider } from "services/auth";
import { ModalBoxProvider } from "components/modalBox/providers/modalBox";
import { QueryClientProvider } from "react-query";
import queryClient from "services/api/query-client";
import { DisplayLoadingProvider } from "components/loadingProgress/providers/loading-provider";

const root = ReactDOM.createRoot(document.getElementById("root") as HTMLElement);
root.render(
  <React.StrictMode>
    <BrowserRouter>
      <ThemeProvider theme={theme}>
        <AuthProvider>
          <DisplayLoadingProvider>
            <QueryClientProvider client={queryClient}>
              <ModalBoxProvider>
                <CssBaseline />
                <App />
              </ModalBoxProvider>
            </QueryClientProvider>
          </DisplayLoadingProvider>
        </AuthProvider>
      </ThemeProvider>
    </BrowserRouter>
  </React.StrictMode>,
);

reportWebVitals();
