import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';
import tailwindcss from '@tailwindcss/vite'; // הייבוא הזה חסר אצלך!
import path from 'path';

export default defineConfig({
  plugins: [
    react(),
    tailwindcss(), // הוספת הפלאגין כאן
  ],
  resolve: {
    alias: {
      "@": path.resolve(__dirname, "./src"),
    },
  },
});