import { createSlice } from "@reduxjs/toolkit";

const roomSlice = createSlice({
    name: "room",
    initialState: {
        rooms: [],
        isPending: true,
        error: null,
    },
    reducers: {
        ROOMS_IS_PENDING(state) {
            state.isPending = true;
            state.rooms = [];
            state.error = null;
        },
        ROOMS_IS_SUCCESS(state, action) {
            const { result } = action.payload;
            state.isPending = false;
            state.error = null;
            state.rooms = result;
        },
        ROOMS_IS_ERROR(state, action) {
            const { error } = action.payload;
            state.isPending = false;
            state.rooms = [];
            state.error = error;
        },
    },
});

export const {
    ROOMS_IS_PENDING,
    ROOMS_IS_SUCCESS,
    ROOMS_IS_ERROR,
} = roomSlice.actions;

export default roomSlice.reducer;
