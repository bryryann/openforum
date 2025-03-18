import axios from 'axios';
import client from '../config/client';

axios.defaults.withCredentials = true;

interface AuthenticationRequest {
    username: string;
    password: string;
};

interface FetchPostOptions {
    method: string;
    headers: Headers;
    body: string;
};

type ApiAuth = (cred: AuthenticationRequest) => Promise<object>;

export const performLogin: ApiAuth = async (credentials) => {
    const response = await axios.post(`${client.API}/auth/login`, postRequest(credentials));
    // TEMPORARY ERROR HANDLING
    return await response.data();
};

export const performRegister: ApiAuth = async (credentials) => {
    const response = await axios.post(`${client.API}/auth/register`, postRequest(credentials));
    // TEMPORARY ERROR HANDLING
    return await response.data();
};

const postRequest = (body: object): FetchPostOptions => {
    const headers = new Headers();
    headers.set('Content-Type', 'application/json');
    return {
        headers,
        method: 'POST',
        body: JSON.stringify(body),
    };
};
