using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class StudentBatchRepository : IStudentBatch
    {
        private readonly AppDbContext _appDbcontext;
        public StudentBatchRepository(AppDbContext appDbcontext)
        {
            _appDbcontext = appDbcontext;
        }
        public async Task<IEnumerable<StudentBatch>> GetAllAsync(int Id)
        {
            return await _appDbcontext.StudentBatch.Where(s=>s.UserId == Id).ToListAsync();
        }
        public async Task<StudentBatch> GetByIdAsync(int Id)
        {
            return await _appDbcontext.StudentBatch.FindAsync(Id);
        }
        public async Task<StudentBatch> AddAsync(StudentBatch studentBatch)
        {
            _appDbcontext.StudentBatch.Add(studentBatch);
            await _appDbcontext.SaveChangesAsync();
            return studentBatch;
        }
        public async Task<StudentBatch> UpdateAsync(StudentBatch studentBatch)
        {
            _appDbcontext.StudentBatch.Update(studentBatch);
            await _appDbcontext.SaveChangesAsync();
            return studentBatch;
        }
        public async Task<StudentBatch> DeleteAsync(int Id)
        {
            var studentBatch = await _appDbcontext.StudentBatch.FindAsync(Id);
            _appDbcontext.StudentBatch.Remove(studentBatch);
            await _appDbcontext.SaveChangesAsync();
            return studentBatch;
        }

        public async Task<IEnumerable<Users>> GetStudentsAsync()
        {
            var students = await (from allusers in _appDbcontext.Users
                                   join userRole in _appDbcontext.UserRole on allusers.Id equals userRole.UserID
                                   join role in _appDbcontext.Roles on userRole.RoleID equals role.Id
                                   where role.RoleName=="Student"
                                   select allusers
                                   ).ToListAsync();
            return students;
        }
    }
}
