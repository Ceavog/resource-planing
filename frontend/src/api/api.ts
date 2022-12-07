import axios from "axios";
import { config } from "config";

const API = axios.create({
  responseType: "json",
  baseURL: config.backendUrl,
});

export default API;
