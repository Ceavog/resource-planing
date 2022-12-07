import axios from "axios";
import { config } from "config";
import { QueryClient } from "react-query";

export const queryClient = new QueryClient();

const API = axios.create({
  responseType: "json",
  baseURL: config.backendUrl,
});

export default API;
