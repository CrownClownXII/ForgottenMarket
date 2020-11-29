import React from "react";
import EqItem from "./EqItem";
import Square from "./Square";

export const ITEM_TYPES = {
    HELMET: 1,
    WEAPON: 2,
    BREASTPLATE: 3,
    SHIELD: 4,
    BOOTS: 5,
};

const EquipmentBoard = ({ eqItems, hanldeClick }) => {
    const renderItem = (type) => {
        const item = eqItems.find((i) => i.equiped && i.type === type);

        if (item) {
            return <EqItem item={item} onClick={hanldeClick} />;
        }
    };

    return (
        <div className={"eq-board "}>
            <div className={"helmet"}>
                <h5>Hełm</h5>
                <Square>{renderItem(ITEM_TYPES.HELMET)}</Square>
            </div>
            <div className={"weapon-a"}>
                <h5>Broń</h5>
                <Square>{renderItem(ITEM_TYPES.WEAPON)}</Square>
            </div>
            <div className={"breastplate"}>
                <h5>Pancerz</h5>
                <Square>{renderItem(ITEM_TYPES.BREASTPLATE)}</Square>
            </div>
            <div className={"weapon-b"}>
                <h5>Tarcza</h5>
                <Square>{renderItem(ITEM_TYPES.SHIELD)}</Square>
            </div>
            <div className={"boots"}>
                <h5>Buty</h5>
                <Square>{renderItem(ITEM_TYPES.BOOTS)}</Square>
            </div>
        </div>
    );
};

export default EquipmentBoard;
