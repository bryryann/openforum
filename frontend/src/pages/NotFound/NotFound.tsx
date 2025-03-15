import React from 'react';
import { useRootClass } from '../../hooks/useRootClass';
import './style.css';

const NotFound: React.FC = () => {
    useRootClass('error-boundary-page');

    return (
        <>
            <h1>404 Not Found.</h1>
            <p>The page you're looking for does not exist or is no longer accessible.</p>
        </>
    );
};

export default NotFound;
