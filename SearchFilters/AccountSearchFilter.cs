namespace ERP.SearchFilters
{
    public class AccountSearchFilter
    {
        public int AccountId {get; set;} = 0;
        public string From { get; set; } = "";
        public string To { get; set; } = "";
        public int Take { get; set; } = 0;
        public int Skip { get; set; } = 0;
    }
}
