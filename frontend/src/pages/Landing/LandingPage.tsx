import React from 'react';
import Header from '@components/shared/Header';
import Banner from '@components/landing/Banner';
import './style.css';

const LandingPage: React.FC = () => {
    return (
        <div id='landing'>
            <Header />
            <Banner />
        </div>
    );
};

export default LandingPage;
