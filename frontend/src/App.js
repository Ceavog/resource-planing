import './App.css';
import {BrowserRouter, Route, Routes} from 'react-router-dom';
import Navbar from "./Components/Navbar";
import Settings from "./Pages/Settings";
import Menu from "./Pages/Menu";
import React from "react";
import Orders from "./Pages/Orders";

function App() {
  return (
      <BrowserRouter>
          <Navbar/>
          <Routes>
              <Route path="/settings" element={<Settings />} />
              <Route path="/menu" element={<Menu /> } />
              <Route path="/orders" element={<Orders />} />
          </Routes>
      </BrowserRouter>
  );
}

export default App;
