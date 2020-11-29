import { createSlice } from "@reduxjs/toolkit";

const chatSlice = createSlice({
    name: "chat",
    initialState: {
        roomId: null,
        userId: null,
        userName: "",
        messages: [],
        isPending: true,
        error: null,
        isHidden: true,
    },
    reducers: {
        CHAT_IS_PENDING(state, action) {
            const { roomId, userId, userName } = action.payload;
            state.isPending = true;
            state.roomId = roomId;
            state.userId = userId;
            state.userName = userName;
            state.messages = [];
            state.error = null;
        },
        CHAT_IS_SUCCESS(state, action) {
            const { messages } = action.payload;
            state.isPending = false;
            state.messages = messages;
            state.error = null;
            state.isHidden = false;
        },
        CHAT_IS_ERROR(state, action) {
            const { error } = action.payload;
            state.isPending = false;
            state.messages = [];
            state.error = error;
        },
        CHAT_IS_HIDDEN(state) {
            state.isHidden = true;
        },
        CHAT_ADD_MESSAGE(state, action) {
            const { message } = action.payload;
            state.messages.push(message)
        },
    },
});

export const {
    CHAT_IS_PENDING,
    CHAT_IS_SUCCESS,
    CHAT_IS_ERROR,
    CHAT_IS_HIDDEN,
    CHAT_ADD_MESSAGE,
} = chatSlice.actions;

export default chatSlice.reducer;
