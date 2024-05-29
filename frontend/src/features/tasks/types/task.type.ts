import { User } from "../../users/types/user.type";

export type Task = {
    id: string;
    title: string;
    description: string;
    tags: string[];
    expirationDate: string;
    finished: boolean;
    user: User;
    priority: Priority;
    createdAt: string;
}

export type Priority = {
    id: string;
    name: string;
}

export type TaskCreate = {
    title: string;
    description: string;
    tags: string[];
    expirationDate: string;
    userId: string;
    priorityId: string;
}