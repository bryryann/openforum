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
    const response = await fetch('/api/auth/login', postRequest(credentials));

    // TEMPORARY ERROR HANDLING
    if (!response.ok) {
        throw new Error('error');
    }
    return await response.json();
};

export const performRegister: ApiAuth = async (credentials) => {
    const response = await fetch('/api/auth/register', postRequest(credentials));

    // TEMPORARY ERROR HANDLING
    if (!response.ok) {
        throw new Error('error');
    }
    return await response.json();
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
