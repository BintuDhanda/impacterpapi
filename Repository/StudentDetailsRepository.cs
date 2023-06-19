using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
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
        public async Task<IEnumerable<StudentDetails>> GetAllAsync()
        {
            var studentDetails = await (from allStudentDetails in _appDbcontext.StudentDetails select new StudentDetails {
                Id = allStudentDetails.Id,
                FirstName = allStudentDetails.FirstName,
                LastName = allStudentDetails.LastName,
                FatherName = allStudentDetails.FatherName,
                MotherName = allStudentDetails.MotherName,
                Gender = allStudentDetails.Gender,
                StudentHeight = allStudentDetails.StudentHeight,
                StudentWeight = allStudentDetails.StudentWeight,
                BodyRemark = allStudentDetails.BodyRemark,
                UserId = allStudentDetails.UserId,
                IsActive = allStudentDetails.IsActive,
                IsDeleted = allStudentDetails.IsDeleted,
                CreatedAt = allStudentDetails.CreatedAt,                             
                Mobile = _appDbcontext.Users.Where(s => s.Id == allStudentDetails.UserId).Select(s => s.UserMobile).FirstOrDefault()
            }).OrderByDescending(o => o.Id).ToListAsync();
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
