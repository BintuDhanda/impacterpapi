using Microsoft.AspNetCore.Mvc;

namespace ERP.Interface
{
    public interface ICommon
    {
        public string SendSMS(string phoneNumber, string message);
    }
}
