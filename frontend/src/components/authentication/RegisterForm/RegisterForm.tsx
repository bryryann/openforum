import React from 'react';
import './style.css';

const RegisterForm: React.FC = () => {
    return (
        <div className="form" id="register-form">
            <div className="form-header">
                <h3>Create account</h3>
                <p>Join OpenForum now!</p>
            </div>

            <form>
                <label htmlFor="username">Username</label>
                <input type="text" name="username" />

                <label htmlFor="password">Password</label>
                <input type="password" name="password" />

                <label>
                    Confirm Password:
                    <input type="password" name="confirm-password" />
                </label>
                <button id="register-btn" type="submit">Sign Up</button>
            </form>
        </div>
    );
};

export default RegisterForm;
