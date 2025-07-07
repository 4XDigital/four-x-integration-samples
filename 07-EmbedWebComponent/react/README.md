# Step 8 - Embed Web Component - React Sample

This sample demonstrates how to embed the [4X Platform Web Component](https://4xdigital.ai) into a React application using standard HTML tags.

[![Open in StackBlitz](https://developer.stackblitz.com/img/open_in_stackblitz.svg)](https://stackblitz.com/edit/four-x-webcomponent-react-sample?file=README.md)

## 🚀 Getting Started

### Prerequisites

- Node.js (v18 or higher recommended)
- npm

### 1. Clone the Repository

```bash
git clone https://github.com/4XDigital/four-x-integration-samples.git
cd ./08-EmbedWebComponent/react
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

The 4X Web Component is loaded via CDN. These tags are added to `index.html`:

```html
<link rel="stylesheet" href="https://cdn.4xdigital.ai/index-0.2.0.css" />
<script src="https://cdn.4xdigital.ai/index-0.2.0.js" defer></script>
```

### Minimum Width Requirement

The component must be rendered inside a container with at least `520px` width.

## 📦 Usage Example

Inside `App.jsx`:

```jsx
<div style="min-width: 520px;">
    <wc-4xd
        web-component-key="<REPLACE_ME_WITH_WEB_COMPONENT_KEY_FROM_STEP_3>"
        seller-id="<REPLACE_ME_WITH_SELLER_ID_FROM_STEP_4>"
        email="<REPLACE_ME_WITH_USER_EMAIL_FROM_STEP_5>"
        route="/home"
        hidden-sidebar="false"
        primary-color="#0040ff"
        secondary-color="#00ffcc"
        lang="en-US">
    </wc-4xd>
</div>
```

✅ Replace `web-component-key`, `seller ID` and `email` with real values from your integration steps.

## 🛠 Built With

- [React](https://react.dev/)
- [Vite](https://vitejs.dev/)
- 4X Web Component

## 🐳 Run with Docker

### 1. Build and run

```bash
docker build -t four-x-embed-web-component-react-sample .
docker run -p 5173:5173 four-x-embed-web-component-react-sample
```

### 2. Or use Docker Compose

```bash
docker-compose up
```

Open your browser at [http://localhost:5173](http://localhost:5173)

## 🧼 License

This sample is provided for demonstration purposes and has no license restrictions
