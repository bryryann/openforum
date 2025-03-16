import { configureStore } from '@reduxjs/toolkit';
import jwtReducer from './reducers/jwt-reducer';

const store = configureStore({
    reducer: {
        jwt: jwtReducer,
    },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export default store;
