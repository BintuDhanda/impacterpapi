namespace ERP.SearchFilters
{
    public class NewsSearchFilter
    {
        public string NewsTitle { get; set; } = "";
        public string From { get; set; } = "";
        public string To { get; set; } = "";
        public int Take { get; set; } = 0;
        public int Skip { get; set; } = 0;
        public int CreatedBy { get; set; }
    }
}
