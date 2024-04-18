using ERP.Interface;
using LMS.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Repository
{
    public class CommonRepository : ICommon
    {
        public string SendSMS(string phoneNumber, string message, string type)
        {
            var result = new SMS(phoneNumber, message, type).Send();
            if (result)
            {
                return "Ok";
            }
            return "Failed";
        }
    }
}
