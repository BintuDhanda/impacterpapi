using FirebaseAdmin.Messaging;
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
        private readonly string type;

        public SMS(string mobile, string message, string type)
        {
            this.mobile = mobile;
            this.message = message;
            this.type = type;
        }
        public bool Send()
        {
            try
            {
                string msg = "";
                switch (type)
                {
                    case "OTPSMS":
                        msg = "Your Mobile number verification OTP is " + message + " Regards, Impact Academy Hisar	";
                        break;
                }

                string user = "impactcampus";
                string password = "K9F2HDNY";
                string senderId = "IMPHSR";
                string entityId = "";
                string strUrl = "http://www.getwaysms.com/vendorsms/pushsms.aspx?user="
                    + user + "&password=" + password + "&msisdn=" + mobile
                     + "&sid=" + senderId + "&msg=" + msg + "&fl=0&gwid=2";
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
                if (!dataString.Contains("SUCCESS"))
                {
                    return false;
                }
                return true;
            }
            catch { return false; }
        }
    }
}
