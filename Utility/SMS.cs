using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LMS.Utilities
{
    public class SMS
    {
        private readonly string mobile;
        private readonly string message;
        private readonly string templateId;

        public SMS(string mobile, string message, string templateId)
        {
            this.mobile = mobile;
            this.message = message;
            this.templateId = templateId;
        }
        public bool Send()
        {
            try
            {
                string user = "impactcampus";
                string password = "K9F2HDNY";
                string senderId = "IIMPCT";
                string entityId = "";
                string strUrl = "http://www.getwaysms.com/vendorsms/pushsms.aspx?user=" 
                    + user + "&password=" + password + "&msisdn=" + mobile 
                    + "&msg=" + message + "&sid=" + senderId + "&fl=0&gwid=2";
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                System.Net.WebRequest request = System.Net.WebRequest.Create(strUrl);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream s = (Stream)response.GetResponseStream();
                StreamReader readStream = new StreamReader(s);
                string dataString = readStream.ReadToEnd();
                s.Close();
                readStream.Close();
                response.Close();
                return true;
            }
            catch { return false; }
        }
    }
}
