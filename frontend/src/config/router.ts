import { createBrowserRouter } from 'react-router-dom';
import LandingPage from '../pages/Landing';
import Auth from '../pages/Auth';
import NotFound from '../pages/NotFound';

export const router = createBrowserRouter([
    {
        path: '/',
        Component: LandingPage,
        ErrorBoundary: NotFound,
    },
    {
        path: '/auth',
        Component: Auth,
    },
]);

