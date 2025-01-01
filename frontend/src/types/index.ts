// 用户相关类型定义
export interface User {
    id: number;
    username: string;
    email: string;
    phoneNumber?: string;
    realName?: string;
    createdAt: string;
    lastLoginAt?: string;
    roles: string[];
}

export interface LoginRequest {
    username: string;
    password: string;
}

export interface RegisterRequest {
    username: string;
    password: string;
    confirmPassword: string;
    email: string;
    phoneNumber?: string;
    realName?: string;
}

export interface LoginResponse {
    accessToken: string;
    tokenType: string;
    expiresIn: number;
    user: User;
}
