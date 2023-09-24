namespace ERP.Utility
{
    public static class TimeZoneConvert
    {
        public static DateTime UtcToIST(DateTime? dt)
        {        
            if(dt !=null)
            {
                return TimeZoneInfo.ConvertTimeFromUtc((DateTime)dt, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            }
            else
            {
                return DateTime.MinValue;
            }
        }
    }
}
