using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using ERP.SearchFilters;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class StudentTokenFeesRepository:IStudentTokenFees
    {
        private readonly AppDbContext _appDbContext;
        public StudentTokenFeesRepository(AppDbContext apDbContext)
        {
            _appDbContext = apDbContext;
        }
        public async Task<IEnumerable<StudentTokenFees>> GetAllAsync()
        {
            return await _appDbContext.StudentTokenFees.ToListAsync();
        }
        public async Task<StudentTokenFees> GetByIdAsync(int Id)
        {
            return await _appDbContext.StudentTokenFees.FindAsync(Id);
        }
        public async Task<StudentTokenFees> AddAsync(StudentTokenFees studentTokenFees)
        {
            studentTokenFees.CreatedAt = DateTime.UtcNow;
            studentTokenFees.IsDeleted = false;
            _appDbContext.StudentTokenFees.Add(studentTokenFees);
            await _appDbContext.SaveChangesAsync();
            return studentTokenFees;
        }
        public async Task<StudentTokenFees> UpdateAsync(StudentTokenFees studentTokenFees)
        {
            studentTokenFees.UpdatedAt = DateTime.UtcNow;
            studentTokenFees.IsDeleted = false;
            _appDbContext.StudentTokenFees.Update(studentTokenFees);
            await _appDbContext.SaveChangesAsync();
            return studentTokenFees;
        }
        public async Task<StudentTokenFees> DeleteAsync(int Id)
        {
            var studentTokenFees = await _appDbContext.StudentTokenFees.FindAsync(Id);
            _appDbContext.StudentTokenFees.Remove(studentTokenFees);
            await _appDbContext.SaveChangesAsync();
            return studentTokenFees;
        }
        public async Task<IEnumerable<StudentTokenFees>> GetStudentTokenFeesByStudentTokenIdAsync(int Id, CommonSearchFilter commonSearchFilter)
        {
            var studentTokenFees = await (from allStudentTokenFees in _appDbContext.StudentTokenFees
                                          where allStudentTokenFees.CreatedAt >= Convert.ToDateTime(commonSearchFilter.From) &&
                                                     allStudentTokenFees.CreatedAt <= Convert.ToDateTime(commonSearchFilter.To)
                                          select new StudentTokenFees
                                          {
                                              Id = allStudentTokenFees.Id,
                                              StudentId = allStudentTokenFees.StudentId,
                                              StudentTokenId = allStudentTokenFees.StudentTokenId,
                                              Deposit = allStudentTokenFees.Deposit,
                                              Refund = allStudentTokenFees.Refund,
                                              Particulars = allStudentTokenFees.Particulars,
                                              IsActive = allStudentTokenFees.IsActive,
                                              IsDeleted = allStudentTokenFees.IsDeleted,
                                              CreatedAt = allStudentTokenFees.CreatedAt,
                                              CreatedBy = allStudentTokenFees.CreatedBy,
                                              UpdatedAt = allStudentTokenFees.UpdatedAt,
                                              UpdatedBy = allStudentTokenFees.UpdatedBy,
                                          })
                                      .Where(b => b.StudentTokenId == Id)
                                      .OrderByDescending(b => b.Id)
                                      .Skip(commonSearchFilter.Skip)
                                      .Take(commonSearchFilter.Take)
                                      .ToListAsync();
            return studentTokenFees;
        }
    }
}
