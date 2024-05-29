import { configureStore } from "@reduxjs/toolkit";
import { usersApi } from "../features/users/api/user-api.slice";
import { tasksApi } from "../features/tasks/api/task-api.slice";
import { priorityApi } from "../features/priorities/api/priority-api.slice";

export const store = configureStore({
  reducer: {
    [usersApi.reducerPath]: usersApi.reducer,
    [tasksApi.reducerPath]: tasksApi.reducer,
    [priorityApi.reducerPath]: priorityApi.reducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware()
      .concat(usersApi.middleware)
      .concat(tasksApi.middleware)
      .concat(priorityApi.middleware),
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
