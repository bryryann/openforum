import React from 'react';
import { useInput } from '../../../hooks/forms';
import { performRegister } from '../../../services/auth-service';
import './style.css';

const RegisterForm: React.FC = () => {
    const username = useInput('text');
    const password = useInput('password');
    const confirmPassword = useInput('password');

    const onSubmit = (e: React.SyntheticEvent) => {
        e.preventDefault();

        if (password.value !== confirmPassword.value)
            return;

        (async function() {
            const res = performRegister({
                username: username.value,
                password: password.value,
            });
            console.log(res);
        })();
    };

    return (
        <div className="form" id="register-form">
            <div className="form-header">
                <h3>Create account</h3>
                <p>Join OpenForum now!</p>
            </div>

            <form onSubmit={onSubmit}>
                <label htmlFor="username">Username</label>
                <input
                    type={username.type}
                    value={username.value}
                    onChange={username.onChange}
                    name="username"
                />

                <label htmlFor="password">Password</label>
                <input
                    type={password.type}
                    value={password.value}
                    onChange={password.onChange}
                    name="password"
                />

                <label>
                    Confirm Password:
                    <input
                        type={confirmPassword.type}
                        value={confirmPassword.value}
                        onChange={confirmPassword.onChange}
                        name="confirm-password"
                    />
                </label>
                <button id="register-btn" type="submit">Sign Up</button>
            </form>
        </div>
    );
};

export default RegisterForm;
