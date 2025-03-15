import React from 'react';
import './style.css';

const RegisterForm: React.FC = () => {
    return (
        <div id="register-form">
            <h3>Create account</h3>
            <p>Join OpenForum now!</p>

            <form>
                <label htmlFor="username">Username: </label>
                <input type="text" name="username" />
                <br />
                <label htmlFor="password">Password: </label>
                <input type="password" name="password" />
                <br />
                <label htmlFor="confirm-password">Confirm Password: </label>
                <input type="password" name="confirm-password" />
                <br />
                <button type="submit">Sign Up</button>
            </form>
        </div>
    );
};

export default RegisterForm;
