import React from 'react'
import EqItem from './EqItem';
import Square from './Square'

const EqItemBoard = ({eqItems, hanldeClick}) => {
    const renderEqItems = () => (
        eqItems.filter(i => !i.equiped).map(item => (
            <Square type={item}>
                {item.eq ? <EqItem item={item} onClick={hanldeClick}/> : null}
            </Square>
        ))
    );

    return (
        <div className={'flex-rw-fs'}>
            {renderEqItems()}
        </div>
    )
}

export default EqItemBoard
