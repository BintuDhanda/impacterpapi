using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using ERP.Utility;
using Microsoft.EntityFrameworkCore;

namespace ERP.Repository
{
    public class StudentHostelRoomBadRentRepository : IStudentHostelRoomBadRent
    {
        private readonly AppDbContext _appDbContext;
        private string[] months = { "", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        public StudentHostelRoomBadRentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<StudentHostelRoomBadRent>> GetAllAsync(int studentId)
        {
            var responseData = await (from h in _appDbContext.Hostels
                                      join hr in _appDbContext.HostelRooms on h.HostelId equals hr.HostelId
                                      join hrb in _appDbContext.HostelRoomBads on hr.HostelRoomId equals hrb.HostelRoomId
                                      join hrbs in _appDbContext.HostelRoomBadStudents on hrb.HostelRoomBadId equals hrbs.HostelRoomBadId
                                      where hrbs.StudentId == studentId && hrb.IsAllocated
                                      select new StudentHostelRoomBadRent
                                      {
                                          Id = hrbs.HostelRoomBadStudentId,
                                          HostelId = h.HostelId,
                                          HostelName = h.HostelName,
                                          RoomId = hr.HostelRoomId,
                                          RoomNo = hr.HostelRoomNo,
                                          BadId = hrb.HostelRoomBadId,
                                          BadNo = hrb.HostelRoomBadNo,
                                          DueAmount = hrb.HostelRoomBadAmount,
                                      }).ToListAsync();
            foreach (var item in responseData)
            {
                var lastPayment = await _appDbContext.
                    HostelRoomBadStudentRents
                    .AsNoTracking().Where(g => g.HostelRoomBadStudentId == item.Id
                    && g.Year == DateTime.Now.Year
                    && g.IsDeleted != true
                    && g.PaymentType != "Security").OrderBy(o => o.HostelRoomBadStudentId).LastOrDefaultAsync();
                var currentMonth = DateTime.Now.Month;
                if (lastPayment != null && lastPayment.Month == currentMonth)
                {
                    var receivedAmount = lastPayment.ReceivedAmount - lastPayment.RefundAmount;
                    var due = item.DueAmount - receivedAmount;
                    item.DueAmount = due;
                    if (due == 0)
                    {
                        item.DisplayMessage = "No dues";
                    }
                    else
                    {
                        item.DisplayMessage = due + " amount dues for this month";
                    }
                }
                else if (lastPayment != null)
                {
                    item.DisplayMessage = "Your hostel rent is due from " + months[lastPayment.Month];
                }
                else
                {
                    item.DisplayMessage = "Your hostel rent is due";
                }
            }
            return responseData;
        }
        public async Task<StudentHostelRoomBadRent> GetByIdAsync(int Id)
        {
            var responseData = await (from h in _appDbContext.Hostels
                                      join hr in _appDbContext.HostelRooms on h.HostelId equals hr.HostelId
                                      join hrb in _appDbContext.HostelRoomBads on hr.HostelRoomId equals hrb.HostelRoomId
                                      join hrbs in _appDbContext.HostelRoomBadStudents on hrb.HostelRoomBadId equals hrbs.HostelRoomBadId
                                      where hrbs.HostelRoomBadStudentId == Id
                                      select new StudentHostelRoomBadRent
                                      {
                                          HostelId = h.HostelId,
                                          HostelName = h.HostelName,
                                          RoomId = hr.HostelRoomId,
                                          RoomNo = hr.HostelRoomNo,
                                          BadId = hrb.HostelRoomBadId,
                                          BadNo = hrb.HostelRoomBadNo,
                                          DueAmount = hrb.HostelRoomBadAmount
                                      }).FirstOrDefaultAsync();
            return responseData;
        }
    }
}
