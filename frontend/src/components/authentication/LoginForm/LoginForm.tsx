import React from 'react';
import './style.css';

/**
 * Login Form for the authentication page. (W.I.P)
 */
const LoginForm: React.FC = () => {
    return (
        <div className="form" id="login-form">
            <div className="form-header">
                <h3>Log In</h3>
                <p>Welcome back to OpenForum.</p>
            </div>

            <form>
                <label htmlFor="username">Username</label>
                <input type="text" name="username" />

                <label htmlFor="password">Password</label>
                <input type="password" name="password" />

                <button id="login-btn" type="submit">Log In</button>
            </form>
        </div>
    );
};

export default LoginForm;
