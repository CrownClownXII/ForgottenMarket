import React, { useRef, useState } from "react";
import IconButton from "@material-ui/core/IconButton";
import TextField from "@material-ui/core/TextField";
import Send from "@material-ui/icons/Send";

const ChatInput = ({ sendMessage }) => {
    const [message, setMessage] = useState(null);
    const inputRef = useRef();

    const onSubmit = (e) => {
        e.preventDefault();

        if (message) {
            sendMessage(message);
            inputRef.current.value = null;
        }
    };

    return (
        <form onSubmit={onSubmit} className="chat-input" autoComplete="off">
            <TextField
                id="message"
                label="Message"
                onChange={(e) => setMessage(e.target.value)}
                className="message-input"
                inputRef={inputRef}
            />
            <IconButton
                aria-label="delete"
                color="primary"
                className="send-btn"
                type="submit"
            >
                <Send />
            </IconButton>
        </form>
    );
};

export default ChatInput;
