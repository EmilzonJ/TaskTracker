import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { Priority } from "../../tasks/types/task.type";
const baseUrl = import.meta.env.VITE_API_BASE_URL;
const apiKey = import.meta.env.VITE_API_KEY;

export const priorityApi = createApi({
  reducerPath: "priorityApi",
  baseQuery: fetchBaseQuery({
    baseUrl,
    prepareHeaders: (headers) => {
      headers.set("X-Api-Key", apiKey);
      return headers;
    },
  }),
  tagTypes: ["Task"],
  endpoints: (builder) => ({
    getAllPriorities: builder.query<Priority[], void>({
        query: () => "priorities",
    }),
  }),
});

export const { useGetAllPrioritiesQuery } = priorityApi;
