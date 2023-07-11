using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using ERP.SearchFilters;
using Microsoft.AspNetCore.Mvc;
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
            studentTokenFees.StudentId = _appDbContext.StudentToken.Where(b => b.StudentTokenId == studentTokenFees.TokenNumber).Select(b => b.StudentId).FirstOrDefault();
            studentTokenFees.StudentTokenId = _appDbContext.StudentToken.Where(_b => _b.StudentTokenId == studentTokenFees.TokenNumber).Select(_b => _b.StudentTokenId).FirstOrDefault();
            studentTokenFees.CreatedAt = DateTime.UtcNow;
            studentTokenFees.IsDeleted = false;
            _appDbContext.StudentTokenFees.Add(studentTokenFees);
            await _appDbContext.SaveChangesAsync();
            return studentTokenFees;
        }
        public async Task<StudentTokenFees> UpdateAsync(StudentTokenFees studentTokenFees)
        {
            studentTokenFees.LastUpdatedAt = DateTime.UtcNow;
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
        public async Task<IEnumerable<StudentTokenFees>> GetStudentTokenFeesByTokenNumberAsync(StudentTokenFeesSearch studentTokenFeesSearch)
        {
            var studentTokenFees = await  _appDbContext.StudentTokenFees
                                          .Where(b => b.StudentTokenId == _appDbContext.StudentToken.Where(w => w.StudentTokenId == studentTokenFeesSearch.TokenNumber).Select(s => s.StudentTokenId).FirstOrDefault())
                                          .Select(stf => new StudentTokenFees
                                          {
                                              StudentTokenFeesId = stf.StudentTokenFeesId,
                                              StudentId = stf.StudentId,
                                              StudentTokenId = stf.StudentTokenId,
                                              Deposit = stf.Deposit,
                                              Refund = stf.Refund,
                                              Particulars = stf.Particulars,
                                              IsActive = stf.IsActive,
                                              IsDeleted = stf.IsDeleted,
                                              CreatedAt = stf.CreatedAt,
                                              CreatedBy = stf.CreatedBy,
                                              LastUpdatedAt = stf.LastUpdatedAt,
                                              LastUpdatedBy = stf.LastUpdatedBy,
                                              BatchName = _appDbContext.Batch.Where(b => b.BatchId == (_appDbContext.StudentToken.Where(st => st.StudentTokenId == stf.StudentTokenId).Select(b => b.BatchId).FirstOrDefault())).Select(x => x.BatchName).FirstOrDefault(),
                                              StudentName = _appDbContext.StudentDetails.Where(sd => sd.StudentId == stf.StudentId).Select(s => s.FirstName + " " + s.LastName).FirstOrDefault(),
                                              Mobile = _appDbContext.Users.Where(u => u.UsersId == (_appDbContext.StudentDetails.Where(sd => sd.StudentId == stf.StudentId).Select(s => s.UserId).FirstOrDefault())).Select(u => u.UserMobile).FirstOrDefault(),
                                          })
                                      .OrderByDescending(b => b.StudentTokenFeesId)
                                      .Skip(studentTokenFeesSearch.Skip)
                                      .Take(studentTokenFeesSearch.Take)
                                      .ToListAsync();
            return studentTokenFees;
        }
        public async Task<IActionResult> TokenIsExist(StudentTokenFeesSearch studentTokenFeesSearch)
        {
            return new JsonResult(await _appDbContext.StudentToken.AnyAsync(x => x.StudentTokenId == studentTokenFeesSearch.TokenNumber));
        }
        public async Task<IActionResult> SumDepositAndRefund(int studentTokenId)
        {
            var Deposit = await _appDbContext.StudentTokenFees.Where(d=>d.StudentTokenId == studentTokenId).SumAsync(s => s.Deposit);
            var Refund = await _appDbContext.StudentTokenFees.Where(r=>r.StudentTokenId == studentTokenId).SumAsync(s => s.Refund);
            var Result = new { Deposit, Refund };

            return new JsonResult(Result);
        }
    }
}
