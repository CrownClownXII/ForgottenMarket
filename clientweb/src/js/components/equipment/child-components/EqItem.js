import React from 'react'

const EqItem = ({item, onClick}) => (
    <div className={'eq-item'} style={{backgroundColor: item.eq.img}} onClick={() => onClick(item.id)}>
        
    </div>
)

export default EqItem
