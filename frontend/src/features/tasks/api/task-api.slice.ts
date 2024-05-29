import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { Task } from "../types/task.type";

const baseUrl = import.meta.env.VITE_API_BASE_URL;
const apiKey = import.meta.env.VITE_API_KEY;

export const tasksApi = createApi({
  reducerPath: "tasksApi",
  baseQuery: fetchBaseQuery({
    baseUrl,
    prepareHeaders: (headers) => {
      headers.set("X-Api-Key", apiKey);
      return headers;
    },
  }),
  tagTypes: ["Task", "User"],
  endpoints: (builder) => ({
    createTask: builder.mutation<Task, Partial<Task>>({
      query: (body) => ({
        url: "tasks",
        method: "POST",
        body,
      }),
      invalidatesTags: [{ type: "User", id: "TASKS" }],
    }),
    updateTask: builder.mutation<Task, Partial<Task>>({
      query: (body) => ({
        url: `tasks/${body.id}`,
        method: "PUT",
        body,
      }),
    }),
    deleteTask: builder.mutation<void, string>({
      query: (id) => ({
        url: `tasks/${id}`,
        method: "DELETE",
      }),
    }),
  }),
});

export const { useCreateTaskMutation } = tasksApi;
