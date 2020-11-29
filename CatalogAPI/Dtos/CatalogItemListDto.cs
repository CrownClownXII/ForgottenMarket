using System.Collections.Generic;

namespace CatalogAPI.Dtos
{
    public class CatalogItemListDto
    {
        public List<CatalogItemDto> List { get; set; }
        public int ItemsOnPageNumber { get; set; }

        public int TotalItemNumber { get; set; }
        public int TotalPages { get; set; }

        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}