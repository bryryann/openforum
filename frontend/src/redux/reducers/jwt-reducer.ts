import { createSlice, PayloadAction } from '@reduxjs/toolkit';

interface JwtState {
    jwt: string;
    isSigned: boolean;
}

const initialState: JwtState = {
    jwt: '',
    isSigned: false,
};

const jwtSlice = createSlice({
    name: 'jwt',
    initialState,
    reducers: {
        set: (state, action: PayloadAction<JwtState>) => {
            if (!state.isSigned) {
                return action.payload;
            }
        },
        clear: (_state, _action) => {
            return initialState;
        },
    },
});

export const { set, clear } = jwtSlice.actions;

export default jwtSlice.reducer;
