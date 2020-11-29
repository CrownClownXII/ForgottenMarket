import { all, takeLatest, put, call, select } from "redux-saga/effects";
import {
    ROOMS_IS_PENDING,
    ROOMS_IS_SUCCESS,
    ROOMS_IS_ERROR,
} from "../slices/roomSlice";
import {
    CHAT_IS_PENDING,
    CHAT_IS_ERROR,
    CHAT_IS_SUCCESS,
} from "../slices/chatSlice";
import { TOGGLE_MESSAGES } from "../slices/layoutSlice";
import { getRooms, getLastestMessageForRoom2 } from "../services/ChatService";

export function* roomWatcherSaga() {
    yield takeLatest(ROOMS_IS_PENDING().type, roomWorkerSaga);
}

function* roomWorkerSaga() {
    try {
        const response = yield call(getRooms);

        yield put({
            ...ROOMS_IS_SUCCESS(),
            payload: { result: response },
        });
    } catch (error) {
        yield put({
            ...ROOMS_IS_ERROR(),
            error,
        });
    }
}

export function* chatWatcherSaga() {
    yield takeLatest(CHAT_IS_PENDING().type, chatWorkerSaga);
}

function* chatWorkerSaga() {
    const {roomId} = yield select(state => state.chat)

    try {
        const response = yield call(() => getLastestMessageForRoom2(roomId));

        yield put({
            ...CHAT_IS_SUCCESS(),
            payload: { messages: response },
        });

        yield put({
            ...TOGGLE_MESSAGES(),
            payload: {isMessagesOpen: false}
        })
    } catch (error) {
        yield put({
            ...CHAT_IS_ERROR(),
            error,
        });
    }
}

export default function* rootSaga() {
    yield all([roomWatcherSaga(), chatWatcherSaga()]);
}
