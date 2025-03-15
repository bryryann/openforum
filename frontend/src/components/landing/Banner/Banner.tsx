import React from 'react';
import './style.css';

const Banner: React.FC = () => {
    return (
        <div id="landing-banner">
            <h2>Making web <span>open.</span></h2>
            <p>
                Join OpenForum today. Share and discuss about anything.
                Free of adverts and general shadiness.
            </p>
            <button>Join Now</button>
        </div>
    )
};

export default Banner;
