namespace Web.Areas.Admin.ViewModels
{
    public class BasePagedListModel<T> where T : class
    {
        public IEnumerable<T> Data { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }
    }
}
