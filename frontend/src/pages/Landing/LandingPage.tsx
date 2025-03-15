import React from 'react';
import { useRootClass } from '../../hooks/useRootClass';
import Header from '@components/shared/Header';
import Banner from '@components/landing/Banner';
import './style.css';

const LandingPage: React.FC = () => {
    useRootClass('landing-page')

    return (
        <>
            <Header />
            <Banner />
        </>
    );
};

export default LandingPage;
