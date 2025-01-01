import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import {
    Container,
    Box,
    Typography,
    TextField,
    Button,
    Link,
    Alert,
    Grid,
} from '@mui/material';
import { authApi } from '../services/api';

const Register: React.FC = () => {
    const navigate = useNavigate();
    const [formData, setFormData] = useState({
        username: '',
        password: '',
        confirmPassword: '',
        email: '',
        phoneNumber: '',
        realName: '',
    });
    const [error, setError] = useState('');

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setFormData(prev => ({
            ...prev,
            [name]: value,
        }));
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        try {
            if (formData.password !== formData.confirmPassword) {
                setError('两次输入的密码不一致');
                return;
            }

            console.log('发送注册请求:', formData);
            await authApi.register(formData);
            navigate('/login');
        } catch (err: any) {
            console.error('注册错误:', err);
            if (err.response) {
                console.error('错误响应:', {
                    status: err.response.status,
                    data: err.response.data,
                    headers: err.response.headers,
                });

                if (err.response.data.errors) {
                    // 将所有验证错误合并成一个字符串
                    const errorMessages = Object.entries(err.response.data.errors)
                        .map(([field, errors]) => `${field}: ${(errors as string[]).join(', ')}`)
                        .join('\n');
                    setError(errorMessages);
                } else {
                    setError(err.response.data?.message || '注册失败，请重试');
                }
            } else if (err.request) {
                console.error('请求错误:', err.request);
                setError('网络错误，请检查网络连接');
            } else {
                console.error('其他错误:', err.message);
                setError(err.message || '注册失败，请重试');
            }
        }
    };

    return (
        <Container component="main" maxWidth="xs">
            <Box
                sx={{
                    marginTop: 8,
                    display: 'flex',
                    flexDirection: 'column',
                    alignItems: 'center',
                }}
            >
                <Typography component="h1" variant="h5">
                    注册
                </Typography>
                <Box component="form" onSubmit={handleSubmit} sx={{ mt: 3 }}>
                    {error && (
                        <Alert 
                            severity="error" 
                            sx={{ 
                                mb: 2,
                                whiteSpace: 'pre-line',  // 保留换行符
                                '& .MuiAlert-message': {
                                    width: '100%'  // 确保消息占用全部宽度
                                }
                            }}
                        >
                            {error}
                        </Alert>
                    )}
                    <Grid container spacing={2}>
                        <Grid item xs={12}>
                            <TextField
                                required
                                fullWidth
                                id="username"
                                label="用户名"
                                name="username"
                                autoComplete="username"
                                value={formData.username}
                                onChange={handleChange}
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <TextField
                                required
                                fullWidth
                                id="realName"
                                label="真实姓名"
                                name="realName"
                                autoComplete="name"
                                value={formData.realName}
                                onChange={handleChange}
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <TextField
                                required
                                fullWidth
                                id="email"
                                label="电子邮件"
                                name="email"
                                autoComplete="email"
                                value={formData.email}
                                onChange={handleChange}
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <TextField
                                required
                                fullWidth
                                id="phoneNumber"
                                label="手机号码"
                                name="phoneNumber"
                                autoComplete="tel"
                                value={formData.phoneNumber}
                                onChange={handleChange}
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <TextField
                                required
                                fullWidth
                                name="password"
                                label="密码"
                                type="password"
                                id="password"
                                autoComplete="new-password"
                                value={formData.password}
                                onChange={handleChange}
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <TextField
                                required
                                fullWidth
                                name="confirmPassword"
                                label="确认密码"
                                type="password"
                                id="confirmPassword"
                                autoComplete="new-password"
                                value={formData.confirmPassword}
                                onChange={handleChange}
                            />
                        </Grid>
                    </Grid>
                    <Button
                        type="submit"
                        fullWidth
                        variant="contained"
                        sx={{ mt: 3, mb: 2 }}
                    >
                        注册
                    </Button>
                    <Box sx={{ textAlign: 'center' }}>
                        <Link href="/login" variant="body2">
                            {"已有账号？立即登录"}
                        </Link>
                    </Box>
                </Box>
            </Box>
        </Container>
    );
};

export default Register;
