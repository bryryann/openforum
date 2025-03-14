import React from 'react';
import './style.css';

/**
 * The website main header component. Will change depending if the
 * user is logged in or not.
 *
 * @version 0.0.1
 */
const Header: React.FC = () => {
    return (
        <header className="main-header">
            <h2>OpenForum</h2>
            <div className="header-btn-list">

                <button>Home</button> {/* Non Functional */}
                <button>About</button> {/* Non Functional */}
                <div className="account-section">
                    <button id="login-button">Log In</button> {/* Non Functional */}
                    <button id="register-button">Register</button> {/* Non Functional */}
                </div>
                <button>FAQ</button> {/* Non Functional */}
            </div>
        </header>
    );
};

export default Header;
