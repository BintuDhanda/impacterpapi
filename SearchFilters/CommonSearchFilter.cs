﻿namespace ERP.SearchFilters
{
    public class CommonSearchFilter
    {
        public string From { get; set; } = "";
        public string To { get; set; } = "";
        public int Take { get; set; } = 0;
        public int Skip { get; set; } = 0;
        public string Mobile { get; set; } = "";
        public int UserId { get; set; } = 0;
    }
}
