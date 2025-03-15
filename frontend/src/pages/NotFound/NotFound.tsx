import React from 'react';
import './style.css';

const NotFound: React.FC = () => {
    return (
        <div id="error-boundary">
            <h1>404 Not Found.</h1>
            <p>The page you're looking for does not exist or is no longer accessible.</p>
        </div>
    );
};

export default NotFound;
