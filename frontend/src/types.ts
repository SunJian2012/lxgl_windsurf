export interface User {
    id: number;
    username: string;
    email: string;
    phoneNumber: string;
    realName: string;
    createdTime: string;
    lastLoginTime?: string;
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
    phoneNumber: string;
    realName: string;
}

export interface LoginResponse {
    accessToken: string;
    tokenType: string;
    expiresIn: number;
    user: User;
}
