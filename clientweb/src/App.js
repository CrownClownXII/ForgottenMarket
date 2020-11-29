import React, { useEffect } from "react";
import Catalog from "./js/components/catalog/Catalog";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import Navbar from "./js/components/layout/navbar/Navbar";
import Sidebar from "./js/components/layout/sidebar/Sidebar";
import Chat from "./js/components/chat/Chat";
import Equipment from './js/components/equipment/Equipment';
import { authOnAppInit } from "./js/services/AuthService";
import { useDispatch, useSelector } from "react-redux";
import { USER_IS_LOGGED, USER_IS_NOT_LOGGED } from "./js/slices/userSlice";
import { ROOMS_IS_PENDING } from "./js/slices/roomSlice";
import axios from "axios";

const App = () => {
    const { isSidebarOpen } = useSelector((state) => state.layout);
    const dispatch = useDispatch();

    useEffect(() => {
        authOnAppInit().then((res) => {
            let action = res ? USER_IS_LOGGED : USER_IS_NOT_LOGGED;

            dispatch(action(res));

            if (res && res.access_token) {
                axios.defaults.headers.common = {
                    Authorization: "Bearer " + res.access_token,
                };

                dispatch(ROOMS_IS_PENDING());
            }
        });
    }, [dispatch]);

    return (
        <Router>
            <Navbar/>
            <Sidebar/>

            <div className={`content ${isSidebarOpen && "active"}`}>
                <Switch>
                    <Route path="/catalog">
                        <Catalog />
                    </Route>
                    <Route path="/">
                        <Equipment />
                    </Route>
                </Switch>

                <Chat />
            </div>
        </Router>
    );
};

export default App;
