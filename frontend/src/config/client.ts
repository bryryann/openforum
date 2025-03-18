const env = import.meta.env;

interface ClientConfig {
    API: string;
};

export default {
    API: env.VITE_API_URL,
} satisfies ClientConfig;

