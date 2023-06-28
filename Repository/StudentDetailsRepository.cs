using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using ERP.SearchFilters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class StudentDetailsRepository : IStudentDetails
    {
        private readonly AppDbContext _appDbcontext;
        public StudentDetailsRepository(AppDbContext appDbcontext)
        {
            _appDbcontext = appDbcontext;
        }
        public async Task<IEnumerable<StudentDetails>> GetAllAsync(CommonSearchFilter commonSearchFilter)
        {
            var studentDetails = await _appDbcontext.StudentDetails
            .Where(sd => !string.IsNullOrEmpty(commonSearchFilter.Mobile) ? (_appDbcontext.Users.Where(s => s.Id == sd.UserId).Select(s => s.UserMobile).FirstOrDefault()) == commonSearchFilter.Mobile : sd.CreatedAt >= Convert.ToDateTime(commonSearchFilter.From).ToUniversalTime() &&
            sd.CreatedAt <= Convert.ToDateTime(commonSearchFilter.To).ToUniversalTime())
            .Select( sd => new StudentDetails 
            {
                Id = sd.Id,
                FirstName = sd.FirstName,
                LastName = sd.LastName,
                FatherName = sd.FatherName,
                MotherName = sd.MotherName,
                Gender = sd.Gender,
                StudentHeight = sd.StudentHeight,
                StudentWeight = sd.StudentWeight,
                BodyRemark = sd.BodyRemark,
                UserId = sd.UserId,
                IsActive = sd.IsActive,
                IsDeleted = sd.IsDeleted,
                CreatedAt = sd.CreatedAt,                             
                Mobile = _appDbcontext.Users.Where(s => s.Id == sd.UserId).Select(s => s.UserMobile).FirstOrDefault(),
                TotalStudent = _appDbcontext.StudentDetails.Where(sd=>sd.IsActive == true).Count(),
            })
            .OrderByDescending(o => o.Id)
            .Skip(commonSearchFilter.Skip)
            .Take(commonSearchFilter.Take)
            .ToListAsync();
            return studentDetails;
        }
        public async Task<StudentDetails> GetByIdAsync(int Id)
        {
            return await _appDbcontext.StudentDetails.Where(s => s.Id == Id).FirstOrDefaultAsync();
        }
        public async Task<StudentDetails> AddAsync(StudentDetails studentDetails)
        {
            studentDetails.CreatedAt = DateTime.UtcNow;
            studentDetails.IsDeleted = false;
            _appDbcontext.StudentDetails.Add(studentDetails);
            await _appDbcontext.SaveChangesAsync();
            return studentDetails;
        }
        public async Task<StudentDetails> UpdateAsync([FromBody] StudentDetails studentDetails)
        {
            studentDetails.CreatedAt = DateTime.UtcNow;
            studentDetails.IsDeleted = false;
            _appDbcontext.StudentDetails.Update(studentDetails);
            await _appDbcontext.SaveChangesAsync();
            return studentDetails;
        }
        public async Task<StudentDetails> DeleteAsync(int Id)
        {
            var studentDetails = await _appDbcontext.StudentDetails.FindAsync(Id);
            _appDbcontext.StudentDetails.Remove(studentDetails);
            await _appDbcontext.SaveChangesAsync();
            return studentDetails;
        }
        public async Task<StudentDetails> GetStudentDetailsByUserIdAsync(int UserId)
        {
            return await _appDbcontext.StudentDetails.Where(s => s.UserId == UserId).FirstOrDefaultAsync();
        }
    }
}
