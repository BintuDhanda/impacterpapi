namespace ERP.SearchFilters
{
    public class UserSearch
    {
        public string UserMobile { get; set; }
        public string IsActive { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Take { get; set; }
        public int CurrentPage { get; set; }
        public int TotalRecords { get; set; }
    }
}
