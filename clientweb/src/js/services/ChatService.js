import axios from "axios";

export const getLastestMessageForRoom = async (roomId, user) => {
    try {
        const result = await fetch(
            `https://localhost:5022/api/chat/message/lastest?roomId=${roomId}`,
            {
                method: "Get",
                headers: {
                    "Content-Type": "application/json",
                    Authorization: `Bearer ${user.access_token}`,
                },
            }
        );

        return result.json();
    } catch (e) {
        console.log(e);
    }

    return [];
};

export const getLastestMessageForRoom2 = async (roomId) => {
    try {
        const result = await axios.get(
            `https://localhost:5022/api/chat/message/lastest?roomId=${roomId}`
        );

        return result.data;
    } catch (e) {
        console.log(e);
    }

    return [];
};

export const getRooms = async () => {
    try {
        const result = await axios.get(`https://localhost:5022/api/chat/rooms`);

        return result.data;
    } catch (e) {
        console.log(e);
    }

    return [];
};
