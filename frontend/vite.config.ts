import path from 'path';

import { defineConfig } from 'vite';
import mkcert from 'vite-plugin-mkcert';
import react from '@vitejs/plugin-react';

// https://vite.dev/config/
export default defineConfig({
  plugins: [react(), mkcert()],
  resolve: {
    alias: {
      '@components': path.resolve(__dirname, './src/components'),
    },
  },
  server: {
    proxy: {
      '/api': {
        target: 'http://localhost:8080', // temporarily use local url
        changeOrigin: true,
        rewrite: (path) => path.replace(/^\/api/, '')
      },
    },
  },
});
