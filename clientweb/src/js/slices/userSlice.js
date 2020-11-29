import { createSlice } from "@reduxjs/toolkit";

const userSlice = createSlice({
    name: "user",
    initialState: {
        user: null,
        isPending: true,
    },
    reducers: {
        USER_IS_LOGGED: {
            reducer(state, action) {
                state.isPending = false;
                state.user = action.payload;
            },
            prepare(res) {
                const payload = {
                    accessToken: res.access_token,
                    id: parseInt(res.profile.userId),
                    login: res.profile.login,
                };

                return { payload };
            },
        },
        USER_IS_NOT_LOGGED(state) {
            state.isPending = false;
            state.user = null;
        },
    },
});

export const { USER_IS_LOGGED, USER_IS_NOT_LOGGED } = userSlice.actions;

export default userSlice.reducer;
