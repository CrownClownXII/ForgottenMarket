import React from 'react'
import Card from '@material-ui/core/Card';

const CatalogItem = ({catalogItem, style}) => {
    const { id, name, description, price } = catalogItem;

    return (
        <div style={{...style}} >

            <Card className="catalog-item">
                <img style={{widht: '100%', height: '150px'}} src={`http://localhost:52059/api/image?catalogItemId=${id}`} />
                <div>
                    <div className="catalog-item-text">
                        <h3 className="catalog-item-title">{name}</h3>
                        <p className="catalog-item-description">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec lacus iaculis, placerat ligula ut, egestas urna. Duis turpis velit, finibus eget euismod quis, semper consequat neque. Quisque porta in purus nec pulvinar. Nam sed metus nec nulla accumsan pharetra. 
                        </p>
                    </div>
                    <span className="catalog-item-price">{price} zł</span>
                </div>
            </Card>

        </div>
    )
}

export default CatalogItem
