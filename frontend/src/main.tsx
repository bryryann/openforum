import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import { Provider } from 'react-redux';
import store from './redux/store';
import App from './App.tsx'
import './index.css'

const root = createRoot(document.getElementById('root')!);

const renderApp = () => {
  root.render(
    <Provider store={store}>
      <StrictMode>
        <App />
      </StrictMode>
    </Provider>
  );
};

renderApp();
