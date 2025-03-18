import React from 'react';
import { useInput } from '../../../hooks/forms';
import { performLogin } from '../../../services/auth-service';
import './style.css';

const LoginForm: React.FC = () => {
    const username = useInput('text');
    const password = useInput('password');

    const onSubmit = (e: React.SyntheticEvent) => {
        e.preventDefault();

        (async function() {
            const res = await performLogin({
                username: username.value,
                password: password.value,
            });
            console.log(res);
        })();
    };

    return (
        <div className="form" id="login-form">
            <div className="form-header">
                <h3>Log In</h3>
                <p>Welcome back to OpenForum.</p>
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

                <button id="login-btn" type="submit">Log In</button>
            </form>
        </div>
    );
};

export default LoginForm;
