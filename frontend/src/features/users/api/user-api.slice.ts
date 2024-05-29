import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { User } from "../types/user.type";
import { Task } from "../../tasks/types/task.type";

const baseUrl = import.meta.env.VITE_API_BASE_URL;
const apiKey = import.meta.env.VITE_API_KEY;

export const usersApi = createApi({
  reducerPath: "usersApi",
  baseQuery: fetchBaseQuery({
    baseUrl,
    prepareHeaders: (headers) => {
      headers.set("X-Api-Key", apiKey);
      return headers;
    },
  }),
  tagTypes: ["User"],
  endpoints: (builder) => ({
    getAllUsers: builder.query<User[], void>({
      query: () => "users",
      providesTags: [{ type: "User", id: "LIST" }],
    }),
    getUserById: builder.query<User, string>({
      query: (id) => `users/${id}`,
      providesTags: [{ type: "User", id: "DETAIL" }],
    }),
    createUser: builder.mutation<User, Partial<User>>({
      query: (body) => ({
        url: "users",
        method: "POST",
        body,
      }),
      invalidatesTags: [{ type: "User", id: "LIST" }],
    }),
    getUserTasks: builder.query<Task[], string>({
      query: (id) => `users/${id}/tasks`,
      providesTags: [{ type: "User", id: "TASKS" }],
    }),
    deleteUser: builder.mutation<void, string>({
      query: (id) => ({
        url: `users/${id}`,
        method: "DELETE",
      }),
      invalidatesTags: [{ type: "User", id: "LIST" }],
    }),
  }),
});

export const { useGetAllUsersQuery, useGetUserByIdQuery, useCreateUserMutation, useGetUserTasksQuery } = usersApi;
