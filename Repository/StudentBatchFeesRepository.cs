using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using ERP.SearchFilters;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class StudentBatchFeesRepository:IStudentBatchFees
    {
        private readonly AppDbContext _appDbcontext;
        public StudentBatchFeesRepository(AppDbContext appDbContext)
        {
            _appDbcontext = appDbContext;
        }
        public async Task<IEnumerable<StudentBatchFees>> GetAllAsync()
        {
            return await _appDbcontext.StudentBatchFees.ToListAsync();
        }
        public async Task<StudentBatchFees> GetByIdAsync(int Id)
        {
            return await _appDbcontext.StudentBatchFees.FindAsync(Id);
        }
        public async Task<StudentBatchFees> AddAsync(StudentBatchFees studentBatchFees)
        {
            studentBatchFees.CreatedAt = DateTime.UtcNow;
            studentBatchFees.IsDeleted = false;
            _appDbcontext.StudentBatchFees.Add(studentBatchFees);
            await _appDbcontext.SaveChangesAsync();
            return studentBatchFees;
        }
        public async Task<StudentBatchFees> UpdateAsync(StudentBatchFees studentBatchFees)
        {
            studentBatchFees.UpdatedAt  = DateTime.UtcNow;
            studentBatchFees.IsDeleted = false;
            _appDbcontext.StudentBatchFees.Update(studentBatchFees);
            await _appDbcontext.SaveChangesAsync();
            return studentBatchFees;
        }
        public async Task<StudentBatchFees> DeleteAsync(int Id)
        {
            var studentBatchFees = await _appDbcontext.StudentBatchFees.FindAsync(Id);
            _appDbcontext.StudentBatchFees.Remove(studentBatchFees);
            await _appDbcontext.SaveChangesAsync();
            return studentBatchFees;
        }
        public async Task<IEnumerable<StudentBatchFees>> GetStudentBatchFeesByStudentBatchIdAsync(int Id,CommonSearchFilter commonSearchFilter)
        {
            var studentBatchFees = await (from allStudentBatchFees in _appDbcontext.StudentBatchFees
                                          where allStudentBatchFees.CreatedAt >= Convert.ToDateTime(commonSearchFilter.From) &&
                                                     allStudentBatchFees.CreatedAt <= Convert.ToDateTime(commonSearchFilter.To)
                                          select new StudentBatchFees
                                      {
                                          Id = allStudentBatchFees.Id,
                                          StudentId = allStudentBatchFees.StudentId,
                                          StudentBatchId = allStudentBatchFees.StudentBatchId,
                                          Deposit = allStudentBatchFees.Deposit,
                                          Refund = allStudentBatchFees.Refund,
                                          Particulars = allStudentBatchFees.Particulars,
                                          IsActive = allStudentBatchFees.IsActive,
                                          IsDeleted = allStudentBatchFees.IsDeleted,
                                          CreatedAt = allStudentBatchFees.CreatedAt,
                                          CreatedBy = allStudentBatchFees.CreatedBy,
                                          UpdatedAt = allStudentBatchFees.UpdatedAt,
                                          UpdatedBy = allStudentBatchFees.UpdatedBy,
                                      })
                                      .Where(b => b.StudentBatchId == Id)
                                      .OrderByDescending(b => b.Id)
                                      .Skip(commonSearchFilter.Skip)
                                      .Take(commonSearchFilter.Take)
                                      .ToListAsync();
            return studentBatchFees;
        }
    }
}
