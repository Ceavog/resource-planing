import LoginView from "./views/login";
import RegisterView from "./views/register";

const GuestRouter = [
  { path: "/login", element: <LoginView /> },
  { path: "/register", element: <RegisterView /> },
];

export default GuestRouter;
