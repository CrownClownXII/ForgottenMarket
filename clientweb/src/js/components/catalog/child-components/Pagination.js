import React from 'react'
import Button from '@material-ui/core/Button';

const Pagination = ({listData, setPage}) => {
    const {totalItemNumber, pageNumber, totalPages} = listData;

    const paging = () => {
        if(totalItemNumber === 0) {
            return;
        }
        
        return [...Array(totalPages).keys()].map(e => (
            <div className="page-item" key={e} onClick={() => setPage(e)}>
                <Button variant={`${e === pageNumber ? 'contained' : 'outlined'}`} color="primary">
                    {e + 1}
                </Button>
            </div>
        ))
    }

    return (
        <div className="pagination">
            {paging()}
        </div>
    )
}

export default Pagination
