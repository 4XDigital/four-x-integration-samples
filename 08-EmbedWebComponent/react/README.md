# 4X Web Component React Sample

This sample demonstrates how to embed the [4X Platform Web Component](https://4xdigital.ai) into a React application using standard HTML tags.

[![Open in StackBlitz](https://developer.stackblitz.com/img/open_in_stackblitz.svg)](https://stackblitz.com/github/your-org/4x-webcomponent-react-sample)

## 🚀 Getting Started

### Prerequisites

- Node.js (v18 or higher recommended)
- npm

### 1. Clone the Repository

```bash
git clone https://github.com/your-org/4x-webcomponent-react-sample.git
cd 4x-webcomponent-react-sample
```

### 2. Install Dependencies

```bash
npm install
```

### 3. Run the App

```bash
npm run dev
```

Your app will be available at `http://localhost:5173`.

## 🔗 Web Component Integration

The 4X Web Component is loaded via CDN. These tags are added to `public/index.html`:

```html
<link rel="stylesheet" href="https://cdn.4xdigital.ai/index-latest.css" />
<script src="https://cdn.4xdigital.ai/index-latest.js?v=latest" defer></script>
```

### Minimum Width Requirement

The component must be rendered inside a container with at least `520px` width.

## 📦 Usage Example

Inside `App.jsx`:

```jsx
<wc-4xd
  web-component-key="your-web-component-key"
  token="your.signed.jwt.token"
  route="/"
  hidden-sidebar="false"
  primary-color="#0040ff"
  secondary-color="#00ffcc"
  lang="en-US"
/>
```

✅ Replace `web-component-key` and `token` with real values from your integration steps.

## 🛠 Built With

- [React](https://react.dev/)
- [Vite](https://vitejs.dev/)
- [4X Web Component](https://cdn.4xdigital.ai)

## 🐳 Run with Docker

### 1. Build and run

```bash
docker build -t 4x-web-sample .
docker run -p 5173:5173 4x-web-sample
```

### 2. Or use Docker Compose

```bash
docker-compose up
```

Open your browser at [http://localhost:5173](http://localhost:5173)

## 🧼 License

This sample is provided for demonstration purposes and has no license restrictions
