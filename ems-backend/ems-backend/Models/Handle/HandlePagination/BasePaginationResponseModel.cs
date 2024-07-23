namespace ems_backend.Models.Handle.HandlePagination
{
    public class BasePaginationResponseModel<T>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public List<T> Data { get; set; }
        public BasePaginationResponseModel(int PageNumber, int pageSize, List<T> data, int totalItem)
        {
            TotalPages = (totalItem % pageSize) == 0 ? (totalItem / pageSize) : (totalItem / pageSize) + 1;
            PageNumber = PageNumber > TotalPages ? TotalPages : PageNumber;
            PageSize = pageSize;
            TotalItems = totalItem;
            Data = data;
        }
    }
}
