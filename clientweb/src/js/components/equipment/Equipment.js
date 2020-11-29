import React, { useState } from "react";
import EquipmentBoard from "./child-components/EquipmentBoard";
import EqItemBoard from "./child-components/EqItemBoard";
import "./Equipment.scss";

const baseEqItems = [
    {
        id: 0,
        eq: {
            img: "green",
        },
        type: 0,
        equiped: false,
    },
    {
        id: 1,
        eq: {
            img: "yellow",
        },
        type: 1,
        equiped: true,
    },
    {
        id: 2,
        eq: {
            img: "blue",
        },
        type: 2,
        equiped: true,
    },
    {
        id: 3,
        type: 0,
        equiped: false,
    },
    {
        id: 4,
        type: 0,
        equiped: false,
    },
];

const Equipment = () => {
    const [eqItems, setEqItems] = useState(baseEqItems);

    const hanldeClick = (id) => {
        const newItems = [...eqItems];
        const item = newItems.find((i) => i.id === id);

        if (item) {
            item.equiped = !item.equiped;
        }

        setEqItems(newItems);
    };

    return (
        <div className={"equipment"}>
            <div className={"eq-item-board"}>
                <EqItemBoard eqItems={eqItems} hanldeClick={hanldeClick} />
            </div>

            <div className={"eq-board"}>
                <EquipmentBoard eqItems={eqItems} hanldeClick={hanldeClick} />
            </div>
        </div>
    );
};

export default Equipment;
