using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using ERP.SearchFilters;
using ERP.Utility;
using Microsoft.AspNetCore.Mvc;
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
            studentBatchFees.StudentId = _appDbcontext.StudentBatch.Where(b => b.RegistrationNumber == studentBatchFees.RegistrationNumber).Select(b => b.StudentId).FirstOrDefault();
            studentBatchFees.StudentBatchId = _appDbcontext.StudentBatch.Where(_b => _b.RegistrationNumber == studentBatchFees.RegistrationNumber).Select(_b => _b.StudentBatchId).FirstOrDefault();
            studentBatchFees.CreatedAt = DateTime.UtcNow;
            studentBatchFees.IsDeleted = false;
            _appDbcontext.StudentBatchFees.Add(studentBatchFees);
            await _appDbcontext.SaveChangesAsync();
            return studentBatchFees;
        }
        public async Task<StudentBatchFees> UpdateAsync(StudentBatchFees studentBatchFees)
        {
            studentBatchFees.LastUpdatedAt  = DateTime.UtcNow;
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
        public async Task<IEnumerable<StudentBatchFees>> GetStudentBatchFeesByRegistrationNumberAsync(StudentBatchFeesSearch studentBatchFeesSearch)
        {
            var studentBatchFees = await  _appDbcontext.StudentBatchFees
                                      .Where(b => b.StudentBatchId == _appDbcontext.StudentBatch.Where(w => w.RegistrationNumber == (studentBatchFeesSearch.RegistrationNumber)).Select(s => s.StudentBatchId).FirstOrDefault())
                                      .Select(sbf =>  new StudentBatchFees
                                      {
                                          StudentBatchFeesId = sbf.StudentBatchFeesId,
                                          StudentId = sbf.StudentId,
                                          StudentBatchId = sbf.StudentBatchId,
                                          Deposit = sbf.Deposit,
                                          Refund = sbf.Refund,
                                          Particulars = sbf.Particulars,
                                          IsActive = sbf.IsActive,
                                          IsDeleted = sbf.IsDeleted,
                                          CreatedAt = TimeZoneConvert.UtcToIST(sbf.CreatedAt),
                                          CreatedBy = sbf.CreatedBy,
                                          LastUpdatedAt = sbf.LastUpdatedAt,
                                          LastUpdatedBy = sbf.LastUpdatedBy,
                                          RegistrationNumber = _appDbcontext.StudentBatch.Where(w => w.RegistrationNumber == studentBatchFeesSearch.RegistrationNumber).Select(s => s.RegistrationNumber).FirstOrDefault(),
                                          BatchName = _appDbcontext.Batch.Where(b => b.BatchId == (_appDbcontext.StudentBatch.Where(sb => sb.StudentBatchId == sbf.StudentBatchId).Select(b => b.BatchId).FirstOrDefault())).Select(x => x.BatchName).FirstOrDefault(),
                                          StudentName = _appDbcontext.StudentDetails.Where(sd => sd.StudentId == sbf.StudentId).Select(s => s.FirstName + " " + s.LastName).FirstOrDefault(),
                                          Mobile = _appDbcontext.Users.Where(u => u.UsersId == (_appDbcontext.StudentDetails.Where(sd => sd.StudentId == sbf.StudentId).Select(s => s.UserId).FirstOrDefault())).Select(u => u.UserMobile).FirstOrDefault(),
                                      })
                                      .OrderByDescending(b => b.StudentBatchFeesId)
                                      .Skip(studentBatchFeesSearch.Skip)
                                      .Take(studentBatchFeesSearch.Take)
                                      .ToListAsync();
            return studentBatchFees;
        }
        public async Task<IActionResult> RegistrationIsExist(StudentBatchFeesSearch studentBatchFeesSearch)
        {
            return new JsonResult(await _appDbcontext.StudentBatch.AnyAsync(x => x.RegistrationNumber == studentBatchFeesSearch.RegistrationNumber));
        }
        public async Task<IActionResult> SumDepositAndRefund(string registrationNumber)
        {
            var Deposit = await  _appDbcontext.StudentBatchFees.Where(sbf => sbf.StudentBatchId == (_appDbcontext.StudentBatch.Where(_b => _b.RegistrationNumber == registrationNumber).Select(_b => _b.StudentBatchId).FirstOrDefault())).SumAsync(s => s.Deposit);
            var Refund = await _appDbcontext.StudentBatchFees.Where(sbf => sbf.StudentBatchId == (_appDbcontext.StudentBatch.Where(_b => _b.RegistrationNumber == registrationNumber).Select(_b => _b.StudentBatchId).FirstOrDefault())).SumAsync(s => s.Refund);
            var Result = new { Deposit, Refund };

            return new JsonResult(Result);
        }
    }
}
