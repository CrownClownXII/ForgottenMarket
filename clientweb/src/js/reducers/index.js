import { combineReducers } from 'redux'
import userReducer from "../slices/userSlice";
import roomSlice from "../slices/roomSlice";
import chatSlice from "../slices/chatSlice";
import layoutSlice from "../slices/layoutSlice";

export default combineReducers({
  user: userReducer,
  room: roomSlice,
  chat: chatSlice,
  layout: layoutSlice
});
