import React from 'react';
import { Link } from 'react-router-dom';
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

                <Link to="#" replace={true}>Home</Link> {/* Non Functional */}
                <Link to="#" replace={true}>About</Link> {/* Non Functional */}
                <div className="account-section">
                    <Link to="/auth" replace={true}>Sign up</Link> {/* Non Functional */}
                </div>
                <Link to="#" replace={true}>FAQ</Link> {/* Non Functional */}
            </div>
        </header>
    );
};

export default Header;
