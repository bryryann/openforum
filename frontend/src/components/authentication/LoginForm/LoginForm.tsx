import React from 'react';
import './style.css';

/**
 * Login Form for the authentication page. (W.I.P)
 */
const LoginForm: React.FC = () => {
    return (
        <div id="login-form">
            <h3>Log In</h3>
            <p>Welcome back to OpenForum.</p>

            <form>
                <label htmlFor="username">Username: </label>
                <input type="text" name="username" />
                <br />
                <label htmlFor="password">Password: </label>
                <input type="password" name="password" />
                <br />
                <button type="submit">Log In</button>
            </form>
        </div>
    );
};

export default LoginForm;
