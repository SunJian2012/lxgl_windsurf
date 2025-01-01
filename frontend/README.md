# 医药流向管理系统 - 前端开发指南

## 开发环境配置

### 必需工具
- Node.js >= 18.0.0
- npm >= 9.0.0
- VSCode（推荐）

### 推荐的 VSCode 插件
- ESLint
- Prettier
- ES7+ React/Redux/React-Native snippets
- Material-UI Snippets

## 本地开发

### 安装依赖
```bash
npm install
```

### 启动开发服务器
```bash
npm run dev
```

### 构建生产版本
```bash
npm run build
```

### 代码检查
```bash
npm run lint
```

## 项目结构说明

```
src/
├── api/           # API 接口定义和 Axios 配置
├── components/    # 可复用的组件
├── hooks/         # 自定义 React Hooks
├── layouts/       # 页面布局组件
├── pages/         # 页面组件
├── store/         # Redux 状态管理
├── styles/        # 全局样式和主题
└── utils/         # 工具函数
```

## 开发规范

### 组件开发规范
- 使用函数组件和 Hooks
- 遵循组件命名约定
- 实现组件的错误边界
- 使用 PropTypes 或 TypeScript 类型

### TypeScript 使用规范
- 为所有 props 定义接口
- 使用类型而不是 any
- 利用泛型增强代码复用性

### 状态管理
- 使用 Redux Toolkit
- 遵循 Redux 最佳实践
- 适当使用 React Context

### 样式开发
- 使用 Material-UI 的样式解决方案
- 遵循主题定制规范
- 保持样式的模块化

## 测试指南

### 单元测试
```bash
npm test
```

### 组件测试
- 使用 React Testing Library
- 编写可访问性测试
- 测试用户交互

## 构建和部署

### 环境变量配置
- 开发环境：`.env.development`
- 生产环境：`.env.production`

### 构建优化
- 代码分割策略
- 资源优化建议
- 性能优化措施

## 常见问题

### 开发环境问题
1. 端口占用解决方案
2. 热重载失效解决方案
3. 依赖冲突解决方案

### 构建问题
1. 构建失败排查步骤
2. 性能问题优化建议
3. 兼容性问题解决方案
