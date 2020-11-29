import React, { useRef, useEffect } from "react";
import Message from "./Message";
import CloseIcon from "@material-ui/icons/Close";
import { useSelector } from "react-redux";

const ChatWindow = ({ messages, setIsHidden }) => {
    const messageWindowRef = useRef();
    const { user } = useSelector((state) => state.user);
    const { roomId, userName } = useSelector((state) => state.chat);

    useEffect(() => {
        messageWindowRef.current.scrollIntoView({
            behavior: "smooth",
            block: "nearest",
            inline: "start",
        });
    }, [messages]);

    const renderChat = messages
        .filter((c) => c.chatRoomId === roomId)
        .map((m, i) => {
            return (
                <Message
                    key={Date.now() * Math.random()}
                    login={m.login}
                    content={m.content}
                    isCurrentUser={user && user.id === m.userId}
                />
            );
        });

    return (
        <>
            <div className="chat-header">
                <span>{userName}</span>
                <CloseIcon fontSize="small" onClick={setIsHidden} />
            </div>
            <div className="chat-window">
                {renderChat}
                <div ref={messageWindowRef}></div>
            </div>
        </>
    );
};

export default ChatWindow;
