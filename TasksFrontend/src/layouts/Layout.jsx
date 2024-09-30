// src/components/Layout.js
import { Outlet } from "react-router-dom";
import Login from "../pages/Login/Login";
import useThemeStore from "../store/themeStore";

const Layout = () => {
  const { isDarkMode, toggleTheme } = useThemeStore();
  return (
    <div
      className={`${
        isDarkMode ? "dark" : ""
      } min-h-screen bg-white dark:bg-gray-900 text-black dark:text-white`}
    >
      <main>
        <Login />
        <Outlet />
        <button
          onClick={toggleTheme}
          className="mt-2 p-2 bg-gray-100 rounded hover:bg-gray-700 dark:bg-gray-400 dark:hover:bg-gray-500"
        >
          Switch to {isDarkMode ? "Light" : "Dark"} Mode
        </button>
      </main>
    </div>
  );
};

export default Layout;
