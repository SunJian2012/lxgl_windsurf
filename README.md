# 医药流向管理系统

## 项目概述
医药流向管理系统是一个基于 ASP.NET Core 和 React 的现代化 Web 应用程序，用于管理医药产品的流向信息。系统提供了完整的药品信息管理、企业信息管理、流向记录管理等功能。

## 技术栈

### 后端
- ASP.NET Core 8.0
- Entity Framework Core
- SQL Server
- AutoMapper
- JWT Authentication
- FluentValidation
- Serilog

### 前端
- React 18.x
- TypeScript 5.x
- Material-UI (MUI)
- Redux Toolkit
- React Router
- Axios
- Vite

## 项目结构
```
lxgl_windsurf/
├── backend/                   # 后端项目
│   └── FlowManagement.Api/
│       ├── Controllers/       # API控制器
│       ├── Models/           # 数据模型
│       ├── Services/         # 业务服务
│       ├── DTOs/             # 数据传输对象
│       ├── Data/             # 数据访问层
│       ├── Validators/       # 请求验证器
│       ├── Configurations/   # 配置文件
│       └── Migrations/       # 数据库迁移
├── frontend/                 # 前端项目
│   ├── src/
│   │   ├── api/            # API 接口定义
│   │   ├── components/     # 通用组件
│   │   ├── hooks/         # 自定义 Hooks
│   │   ├── layouts/       # 布局组件
│   │   ├── pages/         # 页面组件
│   │   ├── store/         # Redux 状态管理
│   │   ├── styles/        # 全局样式
│   │   └── utils/         # 工具函数
│   └── public/            # 静态资源
└── docs/                  # 项目文档
```

## 开发环境要求

### 后端
- .NET 8.0 SDK
- SQL Server 2019+
- Visual Studio 2022 或 VS Code

### 前端
- Node.js >= 18.0.0
- npm >= 9.0.0

## 快速开始

### 后端启动
1. 还原 NuGet 包
```bash
dotnet restore
```

2. 更新数据库
```bash
cd backend/FlowManagement.Api
dotnet ef database update
```

3. 运行项目
```bash
dotnet run
```

### 前端启动
1. 安装依赖
```bash
cd frontend
npm install
```

2. 启动开发服务器
```bash
npm run dev
```

## 已完成功能

### 1. 基础架构
- [x] 项目结构搭建
- [x] 数据库配置
- [x] 用户认证
- [x] API 文档
- [x] 日志系统
- [x] 前端框架

### 2. 用户管理
- [x] 用户注册
- [x] 用户登录
- [ ] 角色管理
- [ ] 权限控制

### 3. 药品管理
- [x] 药品信息 CRUD
- [x] 分页查询
- [x] 关键词搜索
- [ ] 数据导出

## 开发规范

详细的开发规范请参考：
- [后端开发规范](.windsurfrules)
- [前端开发规范](frontend/README.md)

## 错误处理和日志

系统使用分层的错误处理策略：
1. 控制器层：处理 HTTP 请求相关错误
2. 服务层：处理业务逻辑错误
3. 数据访问层：处理数据库操作错误

日志记录：
- 使用 Serilog 进行日志记录
- 日志存储在 `Logs` 目录
- 按日期分割日志文件

## API 文档

- 开发环境：访问 `https://localhost:5001/swagger`
- 生产环境：API 文档将被禁用

## 部署

### 后端部署
1. 发布项目
```bash
dotnet publish -c Release
```

2. 配置 IIS 或其他 Web 服务器

### 前端部署
1. 构建生产版本
```bash
npm run build
```

2. 将 `dist` 目录部署到 Web 服务器

## 贡献指南

1. Fork 项目
2. 创建特性分支
3. 提交更改
4. 推送到分支
5. 创建 Pull Request

## 版本历史

- v0.1.0 (2025-01-01)
  - 初始项目结构
  - 基础用户管理功能
  - 药品信息管理

## 参考文档

- [ASP.NET Core 文档](https://docs.microsoft.com/aspnet/core)
- [React 文档](https://reactjs.org/)
- [Material-UI 文档](https://mui.com/)
- [Entity Framework Core 文档](https://docs.microsoft.com/ef/core/)
