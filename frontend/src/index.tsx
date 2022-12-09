import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";
import reportWebVitals from "./reportWebVitals";
import { ThemeProvider } from "@emotion/react";
import "@fontsource/roboto/300.css";
import "@fontsource/roboto/400.css";
import "@fontsource/roboto/500.css";
import "@fontsource/roboto/700.css";
import theme from "config/theme";
import { BrowserRouter } from "react-router-dom";
import { ModalBoxProvider } from "components/modalBox/providers/modalBox";
import { QueryClientProvider } from "react-query";
import { DisplayLoadingProvider } from "components/loadingProgress/providers/loading-provider";
import { queryClient } from "api";
import { UserProvider } from "api/providers/user-provider";
import AuthMiddleware from "middleware/authMiddleware";

const root = ReactDOM.createRoot(document.getElementById("root") as HTMLElement);
root.render(
  // <React.StrictMode>
  <QueryClientProvider client={queryClient}>
    <BrowserRouter>
      <ThemeProvider theme={theme}>
        <UserProvider>
          <DisplayLoadingProvider>
            <ModalBoxProvider>
              <AuthMiddleware>
                <App />
              </AuthMiddleware>
            </ModalBoxProvider>
          </DisplayLoadingProvider>
        </UserProvider>
      </ThemeProvider>
    </BrowserRouter>
  </QueryClientProvider>,
  // </React.StrictMode>,
);

reportWebVitals();
