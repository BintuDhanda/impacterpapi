using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;


namespace ERP.Repository
{
    public class PushNotificationService
    {
        private readonly IConfiguration _configuration;
        public PushNotificationService(IConfiguration configuration)
        {
            _configuration = configuration;
            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile(_configuration["FirebaseServiceAccountKeyPath"]),
            });
        }

        public async Task SendNotificationToDevice(string deviceToken, string title, string body)
        {
            var message = new Message
            {
                Token = deviceToken,
                Notification = new Notification
                {
                    Title = title,
                    Body = body
                }
            };

            var messaging = FirebaseMessaging.DefaultInstance;
            await messaging.SendAsync(message);
        }
    }
}
