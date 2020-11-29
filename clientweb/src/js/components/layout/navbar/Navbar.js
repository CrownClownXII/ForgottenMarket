import React, { useRef } from "react";
import Menu from "@material-ui/core/Menu";
import MenuItem from "@material-ui/core/MenuItem";
import { AppBar, Toolbar, Typography } from "@material-ui/core";
import { logout } from "../../../services/AuthService";
import { useSelector, useDispatch } from "react-redux";
import { CHAT_IS_PENDING } from "../../../slices/chatSlice";
import {
    TOGGLE_MESSAGES,
    TOGGLE_SETTINGS,
} from "../../../slices/layoutSlice";
import AccountBtn from "./child-components/AccountBtn";
import "./Navbar.scss";

const Navbar = () => {
    const settingsRef = useRef(null);
    const messagesRef = useRef(null);

    const { rooms } = useSelector((state) => state.room);
    const { isMessagesOpen, isSettingsOpen } = useSelector(
        (state) => state.layout
    );

    const dispatch = useDispatch();

    const toggleSettings = () => {
        dispatch({
            ...TOGGLE_SETTINGS(),
            payload: { isOpen: !isSettingsOpen },
        });
    };

    const toggleMessages = () => {
        dispatch({
            ...TOGGLE_MESSAGES(),
            payload: { isOpen: !isMessagesOpen },
        });
    };

    const openChat = (opt) => {
        const payload = {
            roomId: opt.roomId,
            userId: opt.userId,
            userName: opt.userName,
        };

        dispatch({
            ...CHAT_IS_PENDING(),
            payload,
        });
    };

    return (
        <AppBar position="fixed" className="navbar">
            <Toolbar style={{ justifyContent: "space-between" }}>
                <Typography variant="h6" color="inherit">
                    Targ
                </Typography>
                <AccountBtn
                    toggleMessages={toggleMessages}
                    toggleSettings={toggleSettings}
                    settingsRef={settingsRef}
                    messagesRef={messagesRef}
                />
            </Toolbar>

            <Menu
                anchorEl={settingsRef.current}
                keepMounted
                getContentAnchorEl={null}
                anchorOrigin={{ vertical: "bottom", horizontal: "center" }}
                transformOrigin={{ vertical: "top", horizontal: "center" }}
                open={isSettingsOpen}
                onClose={toggleSettings}
            >
                <MenuItem onClick={toggleSettings}>Account</MenuItem>
                <MenuItem onClick={toggleSettings}>Settings</MenuItem>
                <MenuItem onClick={logout}>Logout</MenuItem>
            </Menu>

            <Menu
                anchorEl={messagesRef.current}
                keepMounted
                getContentAnchorEl={null}
                anchorOrigin={{ vertical: "bottom", horizontal: "center" }}
                transformOrigin={{ vertical: "top", horizontal: "center" }}
                open={isMessagesOpen}
                onClose={toggleMessages}
            >
                {rooms.map((r) => (
                    <MenuItem key={r.userId} onClick={() => openChat(r)}>
                        Chat with {r.userName}
                    </MenuItem>
                ))}
            </Menu>
        </AppBar>
    );
};

export default Navbar;
