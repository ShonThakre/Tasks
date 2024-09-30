// src/components/Layout.js
import { Outlet } from "react-router-dom";
import Login from "../pages/Login/Login";

const Layout = () => {
  return (
    <div>
      <main>
        <Login />
        <Outlet />
      </main>
    </div>
  );
};

export default Layout;
