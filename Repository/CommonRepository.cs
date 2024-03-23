using ERP.Interface;
using LMS.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Repository
{
    public class CommonRepository : ICommon
    {
        public string SendSMS(string phoneNumber, string message)
        {
            var result = new SMS(phoneNumber, message, null).Send();
            if (result)
            {
                return "Ok";
            }
            return "Failed";
        }
    }
}
