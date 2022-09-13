import './Styles/App.css';
import {BrowserRouter, Route, Routes} from 'react-router-dom';
import Navbar from "./Components/Navbar";
import Settings from "./Pages/Settings";
import Menu from "./Pages/Menu";
import React from "react";
import Orders from "./Pages/Orders";
import SignInUp from "./Pages/SignInUp";
import Home from "./Pages/Home";
import { CookiesProvider } from "react-cookie";
import PrivateRoutes from "./PrivateRoutes";

function App() {
  return (
      <CookiesProvider>
          <BrowserRouter>
              <Navbar/>
              <Routes>
                  <Route element={<PrivateRoutes/>}>
                      <Route path="/settings" element={<Settings />} />
                      <Route path="/menu" element={<Menu /> } />
                      <Route path="/orders" element={<Orders />} />
                  </Route>
                  <Route path="/SignInUp" element={<SignInUp/>}/>
                  <Route path="/Home" element={<Home/>}/>
              </Routes>
          </BrowserRouter>
      </CookiesProvider>
  );
}

export default App;
