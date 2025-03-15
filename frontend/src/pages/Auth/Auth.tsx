import React from 'react';
import { useRootClass } from '../../hooks/useRootClass';
import LoginForm from '@components/authentication/LoginForm';
import RegisterForm from '@components/authentication/RegisterForm';
import './style.css';


const Auth: React.FC = () => {
    useRootClass('authentication-page');

    return (<>
        <div className="form-section">
            <LoginForm /> {/* Non-Functional */}
            <RegisterForm /> {/* Non-Functional */}
        </div>
    </>);
};

export default Auth;
