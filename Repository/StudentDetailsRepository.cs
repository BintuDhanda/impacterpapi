using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class StudentDetailsRepository:IStudentDetails
    {
        private readonly AppDbContext _appDbcontext;
        public StudentDetailsRepository(AppDbContext appDbcontext)
        {
            _appDbcontext = appDbcontext;
        }
        public async Task<IEnumerable<StudentDetails>> GetAllAsync()
        {
            return await _appDbcontext.StudentDetails.ToListAsync();
        }
        public async Task<StudentDetails> GetByIdAsync(int Id)
        {
            return await _appDbcontext.StudentDetails.Where(s=>s.UserId == Id).FirstOrDefaultAsync();
        }
        public async Task<StudentDetails> AddAsync(StudentDetails studentDetails)
        {
            studentDetails.CreatedAt = DateTime.UtcNow;
            studentDetails.IsDeleted = false;
            _appDbcontext.StudentDetails.Add(studentDetails);
            await _appDbcontext.SaveChangesAsync();
            return studentDetails;
        }
        public async Task<StudentDetails> UpdateAsync(StudentDetails studentDetails)
        {
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
        public async Task<IEnumerable<StudentDetails>> GetStudentDetailsByUserIdAsync(int UserId)
        {
            return await _appDbcontext.StudentDetails.Where(s => s.UserId == UserId).ToListAsync();
        }
    }
}
