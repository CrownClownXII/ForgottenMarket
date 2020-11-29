import React, { useState, useEffect } from "react";
import ChatInput from "./child-components/ChatInput";
import ChatWindow from "./child-components/ChatWindow";
import { useSelector, useDispatch } from "react-redux";
import { CHAT_ADD_MESSAGE, CHAT_IS_HIDDEN } from "../../slices/chatSlice";
import "./Chat.scss";
import { createConnection } from "../../services/hubs/ChatHub";

const Chat = () => {
    const [connection, setConnection] = useState(null);
    
    const { user } = useSelector((state) => state.user);
    const { messages, isHidden, userId, roomId } = useSelector(
        (state) => state.chat
    );

    const dispatch = useDispatch();

    useEffect(() => {
        if (user) {
            const newConnection = createConnection(user.accessToken);
            setConnection(newConnection);
        }
    }, [user]);

    useEffect(() => {
        if (connection) {
            connection
                .start()
                .then(() => {
                    connection.on("ReceiveMessage", (message) => {
                        const payload = { message };

                        dispatch({
                            ...CHAT_ADD_MESSAGE(),
                            payload,
                        });
                    });
                })
                .catch((e) => console.log("Connection failde due to ", e));
        }
    }, [connection, dispatch]);

    const sendMessage = async (content) => {
        const message = {
            content,
            receiverId: userId,
            roomId: roomId,
        };

        if (connection.connectionStarted) {
            try {
                await connection.send("SendMessage", message);
            } catch (e) {
                console.log(e);
            }
        } else {
            alert("No connection to the server yet");
        }
    };

    const hideChat = () => {
        dispatch(CHAT_IS_HIDDEN());
    };

    return (
        <div className={`chat-container ${isHidden && "hidden"}`}>
            <ChatWindow messages={messages} setIsHidden={hideChat} />
            <ChatInput sendMessage={sendMessage} />
        </div>
    );
};

export default Chat;
