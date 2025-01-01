import axios from 'axios';
import { LoginRequest, RegisterRequest, LoginResponse, User } from '../types';

const api = axios.create({
    baseURL: 'http://localhost:5179/api',
    headers: {
        'Content-Type': 'application/json',
    },
});

// 请求拦截器：添加token
api.interceptors.request.use(
    (config) => {
        const token = localStorage.getItem('token');
        if (token) {
            config.headers.Authorization = `Bearer ${token}`;
        }
        return config;
    },
    (error) => {
        return Promise.reject(error);
    }
);

// 响应拦截器：处理错误
api.interceptors.response.use(
    (response) => response,
    (error) => {
        if (error.response?.status === 401) {
            localStorage.removeItem('token');
            window.location.href = '/login';
        }
        return Promise.reject(error);
    }
);

export const authApi = {
    login: async (data: LoginRequest): Promise<LoginResponse> => {
        const response = await api.post<LoginResponse>('/users/login', data);
        return response.data;
    },

    register: async (data: RegisterRequest): Promise<User> => {
        const response = await api.post<User>('/users/register', data);
        return response.data;
    },

    getCurrentUser: async (): Promise<User> => {
        const response = await api.get<User>('/users/me');
        return response.data;
    },

    checkUsername: async (username: string): Promise<boolean> => {
        const response = await api.get<{ exists: boolean }>(`/users/check-username/${username}`);
        return response.data.exists;
    },

    checkEmail: async (email: string): Promise<boolean> => {
        const response = await api.get<{ exists: boolean }>('/users/check-email', {
            params: { email },
        });
        return response.data.exists;
    },
};
