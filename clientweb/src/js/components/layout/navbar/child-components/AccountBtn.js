import React from "react";
import Badge from "@material-ui/core/Badge";
import EmailIcon from "@material-ui/icons/Email";
import SettingsIcon from "@material-ui/icons/Settings";
import { login } from "../../../../services/AuthService";
import { useSelector } from "react-redux";

const AccountBtn = ({
    toggleMessages,
    toggleSettings,
    settingsRef,
    messagesRef,
}) => {
    const { user } = useSelector((state) => state.user);

    if (user) {
        return (
            <div className="action-btns">
                <Badge badgeContent={11} color="secondary">
                    <EmailIcon
                        onClick={toggleMessages}
                        className="action-btn"
                        ref={settingsRef}
                    />
                </Badge>

                <SettingsIcon
                    onClick={toggleSettings}
                    className="action-btn settings-btn "
                    ref={messagesRef}
                />
            </div>
        );
    }

    return <span onClick={login}>Logowanie</span>;
};

export default AccountBtn;
