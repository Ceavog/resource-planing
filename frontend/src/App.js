import './Styles/App.css';
import {BrowserRouter, Route, Routes} from 'react-router-dom';
import Navbar from "./Components/Navbar";
import Settings from "./Pages/Settings";
import Menu from "./Pages/Menu";
import React from "react";
import Orders from "./Pages/Orders";
import SignInUp from "./Pages/SignInUp";
import LandingPage from "./Pages/LandingPage";
import { CookiesProvider } from "react-cookie";

function App() {
  return (
      <CookiesProvider>
          <BrowserRouter>
              <Navbar/>
              <Routes>
                  <Route path="/settings" element={<Settings />} />
                  <Route path="/menu" element={<Menu /> } />
                  <Route path="/orders" element={<Orders />} />
                  <Route path="/SignInUp" element={<SignInUp/>}/>
                  <Route path="/LandingPage" element={<LandingPage/>}/>
              </Routes>
          </BrowserRouter>
      </CookiesProvider>
  );
}

export default App;
