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
        public async Task<IEnumerable<StudentBatch>> GetStudentBatchByStudentId(int Id)
        {
            var studentBatch = await (from allStudentBatch in _appDbcontext.StudentBatch
                                      select new StudentBatch
                                      {
                                          StudentBatchId = allStudentBatch.StudentBatchId,
                                          DateOfJoin = allStudentBatch.DateOfJoin,
                                          BatchStartDate = allStudentBatch.BatchStartDate,
                                          BatchEndDate = allStudentBatch.BatchEndDate,
                                          StudentId = allStudentBatch.StudentId,
                                          BatchId = allStudentBatch.BatchId,
                                          RegistrationNumber = allStudentBatch.RegistrationNumber,
                                          IsActive = allStudentBatch.IsActive,
                                          IsDeleted = allStudentBatch.IsDeleted,
                                          CreatedAt = allStudentBatch.CreatedAt,
                                          CreatedBy = allStudentBatch.CreatedBy,
                                          UpdatedAt = allStudentBatch.UpdatedAt,
                                          UpdatedBy = allStudentBatch.UpdatedBy,
                                          BatchName = _appDbcontext.Batch.Where(b => b.Id == allStudentBatch.BatchId).Select(b => b.BatchName).FirstOrDefault(),
                                      }).Where(b=>b.StudentId==Id).OrderByDescending(b => b.StudentBatchId).ToListAsync();
            return studentBatch;
        }
        public async Task<StudentBatch> GetByIdAsync(int Id)
        {
            return await _appDbcontext.StudentBatch.FindAsync(Id);
        }
        public async Task<StudentBatch> AddAsync(StudentBatch studentBatch)
        {
            studentBatch.CreatedAt = DateTime.UtcNow;
            studentBatch.IsDeleted = false;
            _appDbcontext.StudentBatch.Add(studentBatch);
            await _appDbcontext.SaveChangesAsync();
            return studentBatch;
        }
        public async Task<StudentBatch> UpdateAsync(StudentBatch studentBatch)
        {
            studentBatch.UpdatedAt = DateTime.UtcNow;
            studentBatch.IsDeleted = false;
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
