
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Spreadsheet;
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

                    var notifications = await _appDbContext.UserNotification.Where(w=>w.IsProcessed==false).Take(10).ToListAsync();

                    foreach (var notification in notifications)
                    {
                        if(notification.SendToType=="0")
                        {

                            var usersForSendNotifications = await (
                             from u in _appDbContext.Users
                             where !_appDbContext.UserSendNotification.Any(usn => u.UsersId == usn.UserId && _appDbContext.UserNotification.Any(un => usn.UserNotificationId == un.UserNotificationId))
                             select u
                            ).Take(10).ToListAsync();


                            foreach (var user in usersForSendNotifications)
                            {
                                var userNotifiction = new UserSendNotification()
                                {
                                     SentStatus=false,
                                     UserNotificationId=notification.UserNotificationId,
                                     UserId=user.UsersId,
                                };

                                _appDbContext.UserSendNotification.Add(userNotifiction);
                                await _appDbContext.SaveChangesAsync();

                            }
                            
                        }
                        else if(notification.SendToType == "CourseCategory")
                        {
                            var usersForSendNotifications = await (from cc in _appDbContext.CourseCategory
                                        join c in _appDbContext.Course on cc.CourseCategoryId equals c.CourseCategoryId
                                        join cb in _appDbContext.Batch on c.CourseId equals cb.CourseId
                                        join sb in _appDbContext.StudentBatch on cb.BatchId equals sb.BatchId
                                        join sd in _appDbContext.StudentDetails on sb.StudentId equals sd.StudentId
                                        join u in _appDbContext.Users on sd.UserId equals u.UsersId
                                        where cc.CourseCategoryId == Convert.ToInt32(notification.SendToId) &&
                                          !_appDbContext.UserSendNotification
                                         .Any(usn => u.UsersId == usn.UserId && _appDbContext.UserNotification
                                         .Any(un => usn.UserNotificationId == un.UserNotificationId))
                                        select u
                                        ).Take(10).ToListAsync();
                           

                            foreach (var user in usersForSendNotifications)
                            {
                                var userNotifiction = new UserSendNotification()
                                {
                                    SentStatus = false,
                                    UserNotificationId = notification.UserNotificationId,
                                    UserId = user.UsersId,
                                };

                                _appDbContext.UserSendNotification.Add(userNotifiction);
                                await _appDbContext.SaveChangesAsync();

                            }
                        }

                        else if (notification.SendToType == "Course")
                        {
                            var usersForSendNotifications = await (
                                                                   from c in _appDbContext.Course
                                                                   join cb in _appDbContext.Batch on c.CourseId equals cb.CourseId
                                                                   join sb in _appDbContext.StudentBatch on cb.BatchId equals sb.BatchId
                                                                   join sd in _appDbContext.StudentDetails on sb.StudentId equals sd.StudentId
                                                                   join u in _appDbContext.Users on sd.UserId equals u.UsersId
                                                                   where c.CourseId == Convert.ToInt32(notification.SendToId) &&
                                                                     !_appDbContext.UserSendNotification
                                                                    .Any(usn => u.UsersId == usn.UserId && _appDbContext.UserNotification
                                                                    .Any(un => usn.UserNotificationId == un.UserNotificationId))
                                                                   select u
                                        ).Take(10).ToListAsync();


                            foreach (var user in usersForSendNotifications)
                            {
                                var userNotifiction = new UserSendNotification()
                                {
                                    SentStatus = false,
                                    UserNotificationId = notification.UserNotificationId,
                                    UserId = user.UsersId,
                                };

                                _appDbContext.UserSendNotification.Add(userNotifiction);
                                await _appDbContext.SaveChangesAsync();

                            }
                        }
                        else if (notification.SendToType == "Batch")
                        {
                            var usersForSendNotifications = await (                                                                
                                                                   from cb in _appDbContext.Batch
                                                                   join sb in _appDbContext.StudentBatch on cb.BatchId equals sb.BatchId
                                                                   join sd in _appDbContext.StudentDetails on sb.StudentId equals sd.StudentId
                                                                   join u in _appDbContext.Users on sd.UserId equals u.UsersId
                                                                   where cb.BatchId == Convert.ToInt32(notification.SendToId) &&
                                                                     !_appDbContext.UserSendNotification
                                                                    .Any(usn => u.UsersId == usn.UserId && _appDbContext.UserNotification
                                                                    .Any(un => usn.UserNotificationId == un.UserNotificationId))
                                                                   select u
                                        ).Take(10).ToListAsync();


                            foreach (var user in usersForSendNotifications)
                            {
                                var userNotifiction = new UserSendNotification()
                                {
                                    SentStatus = false,
                                    UserNotificationId = notification.UserNotificationId,
                                    UserId = user.UsersId,
                                };

                                _appDbContext.UserSendNotification.Add(userNotifiction);
                                await _appDbContext.SaveChangesAsync();

                            }
                        }
                        else if (notification.SendToType == "Mobile")
                        {
                            var usersForSendNotifications = await (
                                                                   
                                                                   from u in _appDbContext.Users 
                                                                   where u.UserMobile == notification.SendToId &&
                                                                     !_appDbContext.UserSendNotification
                                                                    .Any(usn => u.UsersId == usn.UserId && _appDbContext.UserNotification
                                                                    .Any(un => usn.UserNotificationId == un.UserNotificationId))
                                                                   select u
                                        ).Take(10).ToListAsync();


                            foreach (var user in usersForSendNotifications)
                            {
                                var userNotifiction = new UserSendNotification()
                                {
                                    SentStatus = false,
                                    UserNotificationId = notification.UserNotificationId,
                                    UserId = user.UsersId,
                                };

                                _appDbContext.UserSendNotification.Add(userNotifiction);
                                await _appDbContext.SaveChangesAsync();

                            }
                        }
                    }
                    // You can implement a queue or fetch notifications from a database here.
                    // For the sake of this example, I'll use a simple timer to demonstrate sending a notification every 30 seconds.         

                    try
                    {

                        var pendingSendNotifications =await  _appDbContext.UserSendNotification.Where(w=>w.SentStatus==false).Take(5).ToListAsync();
                        foreach (var notification in pendingSendNotifications)
                        {
                            var deviceToken = await _appDbContext.UserDeviceToken.Where(w => w.UserId == notification.UserId).Select(s => s.UserToken).ToListAsync(); // Replace this with the actual user's device token.
                            var title = await _appDbContext.UserNotification.Where(un=>un.UserNotificationId==notification.UserNotificationId).
                                Select(s=>s.Title).FirstOrDefaultAsync();

                            var body = await _appDbContext.UserNotification.Where(un => un.UserNotificationId == notification.UserNotificationId).
                                Select(s => s.Body).FirstOrDefaultAsync();

                            foreach(var dt in deviceToken)
                            {
                                await pushNotificationService.SendNotificationToDevice(dt, title, body);                             
                            }
                            notification.SentStatus = true;
                             _appDbContext.UserSendNotification.Update(notification);
                            _appDbContext.SaveChanges();
                            // Wait for 30 seconds before sending the next notification.
                        }

                        await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
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
