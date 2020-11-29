import React, { useState, useEffect, useRef } from "react";
import {
  List,
  AutoSizer,
  WindowScroller,
  CellMeasurer,
  CellMeasurerCache,
} from "react-virtualized";
import CatalogItem from "./child-components/CatalogItem";
import Pagination from "./child-components/Pagination";

const Catalog = () => {
  const cache = useRef(
    new CellMeasurerCache({
      fixedWidth: true,
      defaultHeight: 300,
    })
  );

  const [catalogItemList, setCatalogItemList] = useState({
    totalItemNumber: 0,
    list: [],
    pageItemNumber: 0
  });
  
  const [filters, setFilters] = useState({
    pageSize: 10,
    pageNumber: 0
  })

  useEffect(() => {
    const queryString = Object.keys(filters).map(key => key + '=' + filters[key]).join('&');

    fetch(`http://localhost:52059/api/catalog/list?${queryString}`)
      .then(res => res.json())
      .then(res => setCatalogItemList(res))
  }, [filters]);

  const renderList = ({height, scrollTop}) => {
    return (
      <div>
        <AutoSizer disableHeight >
          {({width}) => (
              <List
                autoHeight
                height={height}
                width={width}
                scrollTop={scrollTop}
                rowHeight={cache.current.rowHeight}
                deferredMeasurementCache={cache.current}
                rowCount={catalogItemList.list.length}
                rowRenderer={rowRenderer}
                overscanRowCount={5}
                className="catalog"
            />
          )}
        </AutoSizer>
      </div>
    )
  }

  const rowRenderer = ({ key, index, style, parent }) => {
    const catalogItem = catalogItemList.list[index];

    return (
      <CellMeasurer
        key={key}
        cache={cache.current}
        parent={parent}
        columnIndex={0}
        rowIndex={index}
      >
        <CatalogItem catalogItem={catalogItem} style={style}/>
      </CellMeasurer>
    );
  }

  return (
    <div>
      <WindowScroller>
        {renderList}
      </WindowScroller>

      <Pagination listData={catalogItemList} setPage={(e) => setFilters({...filters, pageNumber: e})} />
    </div>
  );
};

export default Catalog;