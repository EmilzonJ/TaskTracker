import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App.tsx";
import "./index.css";

import { Provider } from "react-redux";
import { store } from "./store/store.ts";

import { createBrowserRouter, RouterProvider } from "react-router-dom";
import UserDetailPage from "./pages/detail/UserDetailPage.tsx";

const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
  },
  {
    path: "/users",
    element: <App />,
  },
  {
    path: "/users/:id/tasks",
    element: <UserDetailPage />
  }
]);

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
    <Provider store={store}>
      <RouterProvider router={router} />
    </Provider>
  </React.StrictMode>
);
