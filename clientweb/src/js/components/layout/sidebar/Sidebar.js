import React, { useMemo } from "react";
import { Link } from "react-router-dom";
import {
    Drawer,
    List,
    Divider,
    ListItem,
    ListItemIcon,
    ListItemText,
    IconButton
} from "@material-ui/core";
import { useSelector, useDispatch } from "react-redux";
import { TOGGLE_SIDEBAR } from "../../../slices/layoutSlice";
import HomeIcon from "@material-ui/icons/Home";
import LocalGroceryStoreIcon from "@material-ui/icons/LocalGroceryStore";
import ChevronRightIcon from "@material-ui/icons/ArrowBackIosOutlined";
import ChevronLeftIcon from "@material-ui/icons/ArrowForwardIosOutlined";
import "./Sidebar.scss";

const Sidebar = () => {
    const { isSidebarOpen } = useSelector((state) => state.layout);
    const dispatch = useDispatch();

    const handleDrawerClose = () => {
        dispatch({
            ...TOGGLE_SIDEBAR(),
            payload: { isOpen: !isSidebarOpen },
        });
    };

    const actionLinks = useMemo(
        () => () => (
            <List>
                <ListItem component={Link} to="/" key={2} button>
                    <ListItemIcon>
                        <HomeIcon />
                    </ListItemIcon>
                    <ListItemText primary={"Home"} />
                </ListItem>
                <ListItem component={Link} to="/catalog" key={1} button>
                    <ListItemIcon>
                        <LocalGroceryStoreIcon />
                    </ListItemIcon>
                    <ListItemText primary={"Chat"} />
                </ListItem>
            </List>
        ),
        []
    );

    return (
        <div>
            <Drawer
                className="drawer"
                variant="permanent"
                anchor="left"
                open={isSidebarOpen}
                classes={{
                    paper: isSidebarOpen ? "drawer-open" : "drawer-close",
                }}
            >
                <div className="drawer-header">
                    <IconButton onClick={handleDrawerClose}>
                        {isSidebarOpen ? (
                            <ChevronRightIcon fontSize='small' />
                        ) : (
                            <ChevronLeftIcon fontSize='small'/>
                        )}
                    </IconButton>
                </div>
                <Divider />
                {actionLinks()}
            </Drawer>
        </div>
    );
};

export default Sidebar;
