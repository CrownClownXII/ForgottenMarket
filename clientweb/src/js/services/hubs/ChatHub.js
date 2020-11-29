import { HubConnectionBuilder } from "@microsoft/signalr";

export const createConnection = (token) => {
    const option = {
        transport: 4,
        accessTokenFactory: () => token,
    };

    const newConnection = new HubConnectionBuilder()
        .withUrl("https://localhost:5022/hubs/chat", option)
        .withAutomaticReconnect()
        .build();

    return newConnection;
};
