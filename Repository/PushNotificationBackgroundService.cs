
using ERP.ERPDbContext;
using ERP.Models;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Repository
{
    public class PushNotificationBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly AppDbContext _appDbContext;

        public PushNotificationBackgroundService(IServiceProvider serviceProvider, AppDbContext appDbContext)
        {
            _serviceProvider = serviceProvider;
            _appDbContext = appDbContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var pushNotificationService = scope.ServiceProvider.GetRequiredService<PushNotificationService>();
                 
                
                while (!stoppingToken.IsCancellationRequested)
                {

                    var notifications = await _appDbContext.UserNotification.Where(w=>w.IsProcessed==false).Take(50).ToListAsync();

                    foreach (var notification in notifications)
                    {
                        if(notification.SendToType=="0")
                        {
                            var users =  await _appDbContext.Users.Select(s=> new UserSendNotification
                            {
                                UserId= ,
                                UserNotificationId = notification.UserNotificationId,
                                SentStatus = false,


                            })ToListAsync();
                            _appDbContext.UserSendNotification.AddRange(users);
                            await _appDbContext.SaveChangesAsync()
                        }
                    }
                    // You can implement a queue or fetch notifications from a database here.
                    // For the sake of this example, I'll use a simple timer to demonstrate sending a notification every 30 seconds.

                    var deviceToken = "USER_DEVICE_TOKEN"; // Replace this with the actual user's device token.
                    var title = "Notification Title";
                    var body = "Notification Body";

                    try
                    {
                        //await pushNotificationService.SendNotificationToDevice(deviceToken, title, body);
                        // Wait for 30 seconds before sending the next notification.
                       // await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions here.
                        // You might want to log errors and/or implement retry mechanisms.
                    }
                }
            }
        }
    }
}
