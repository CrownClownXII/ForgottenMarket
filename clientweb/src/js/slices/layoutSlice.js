import { createSlice } from "@reduxjs/toolkit";

const layoutSlice = createSlice({
    name: "layout",
    initialState: {
        isSidebarOpen: true,
        isMessagesOpen: false,
        settings: false,
    },
    reducers: {
        TOGGLE_SIDEBAR(state, action) {
            state.isSidebarOpen = action.payload.isOpen;
            state.isMessagesOpen = false;
            state.isSettingsOpen = false;
        },
        TOGGLE_MESSAGES(state, action) {
            state.isMessagesOpen = action.payload.isOpen;
            state.isSettingsOpen = false;
        },
        TOGGLE_SETTINGS(state, action) {
            state.isMessagesOpen = false;
            state.isSettingsOpen = action.payload.isOpen;
        },
    },
});

export const {
    TOGGLE_SIDEBAR,
    TOGGLE_MESSAGES,
    TOGGLE_SETTINGS,
} = layoutSlice.actions;

export default layoutSlice.reducer;
