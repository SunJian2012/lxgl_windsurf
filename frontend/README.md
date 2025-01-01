# 医药企业流向管理系统 - 前端

## 项目简介

本项目是医药企业流向管理系统的前端部分，使用 React + TypeScript + Vite 构建。

## 技术栈

- React 18.x
- TypeScript 5.x
- Vite
- Material-UI (MUI)
- Redux Toolkit
- React Router
- Axios

## 开发环境要求

- Node.js >= 18.0.0
- npm >= 9.0.0

## 项目结构

```
frontend/
├── src/                # 源代码目录
│   ├── api/           # API 接口定义
│   ├── components/    # 通用组件
│   ├── hooks/         # 自定义 Hooks
│   ├── layouts/       # 布局组件
│   ├── pages/         # 页面组件
│   ├── store/         # Redux 状态管理
│   ├── styles/        # 全局样式
│   ├── types/         # TypeScript 类型定义
│   └── utils/         # 工具函数
├── public/            # 静态资源
└── tests/             # 测试文件
```

## 开发指南

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

### 运行测试
```bash
npm test
```

## 代码规范

- 使用 ESLint 进行代码检查
- 使用 Prettier 进行代码格式化
- 遵循项目的 TypeScript 配置
- 组件和函数使用 JSDoc 注释

## 提交规范

提交信息格式：
```
<类型>: <描述>

[可选的详细描述]

[可选的脚注]
```

类型包括：
- feat: 新功能
- fix: 修复问题
- docs: 文档修改
- style: 代码格式修改
- refactor: 代码重构
- test: 测试用例修改
- chore: 其他修改

## 注意事项

1. 确保代码提交前已经通过所有测试
2. 保持代码风格一致性
3. 及时更新文档
4. 遵循组件设计原则
5. 注意性能优化

## 相关文档

- [React 官方文档](https://reactjs.org/)
- [Material-UI 文档](https://mui.com/)
- [TypeScript 文档](https://www.typescriptlang.org/)
- [Vite 文档](https://vitejs.dev/)

## Expanding the ESLint configuration

If you are developing a production application, we recommend updating the configuration to enable type aware lint rules:

- Configure the top-level `parserOptions` property like this:

```js
export default tseslint.config({
  languageOptions: {
    // other options...
    parserOptions: {
      project: ['./tsconfig.node.json', './tsconfig.app.json'],
      tsconfigRootDir: import.meta.dirname,
    },
  },
})
```

- Replace `tseslint.configs.recommended` to `tseslint.configs.recommendedTypeChecked` or `tseslint.configs.strictTypeChecked`
- Optionally add `...tseslint.configs.stylisticTypeChecked`
- Install [eslint-plugin-react](https://github.com/jsx-eslint/eslint-plugin-react) and update the config:

```js
// eslint.config.js
import react from 'eslint-plugin-react'

export default tseslint.config({
  // Set the react version
  settings: { react: { version: '18.3' } },
  plugins: {
    // Add the react plugin
    react,
  },
  rules: {
    // other rules...
    // Enable its recommended rules
    ...react.configs.recommended.rules,
    ...react.configs['jsx-runtime'].rules,
  },
})
```
