using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class StudentTokenRepository:IStudentToken
    {
        private readonly AppDbContext _appDbContext;
        public StudentTokenRepository(AppDbContext apDbContext)
        {
            _appDbContext = apDbContext;
        }
        public async Task<IEnumerable<StudentToken>> GetAllAsync()
        {
            return await _appDbContext.StudentToken.ToListAsync();
        }
        public async Task<StudentToken> GetByIdAsync(int Id)
        {
            return await _appDbContext.StudentToken.FindAsync(Id);
        }
        //public async Task<StudentToken> AddAsync(int StudentId, int BatchId)
        //{
        //    var record = await _appDbContext.StudentToken.Where(u => u.StudentId == StudentId && u.BatchId == BatchId).FirstOrDefaultAsync();
        //    if (record == null)
        //    {
        //        var tokenValidity = await _appDbContext.TokenValidity.Where(b => b.BatchId == BatchId).FirstOrDefaultAsync();
        //        using (var transaction = await _appDbContext.Database.BeginTransactionAsync())
        //        {
        //            try
        //            {
        //                var token = await _appDbContext.StudentToken.OrderByDescending(s => s.Id).FirstOrDefaultAsync();
        //                if (token != null && tokenValidity != null)
        //                {
        //                    var newToken = new StudentToken()
        //                    {
        //                        TokenFee = tokenValidity.Amount,
        //                        ValidFrom = System.DateTime.UtcNow,
        //                        ValidUpto = System.DateTime.UtcNow.AddDays(tokenValidity.Validity),
        //                        BatchId = BatchId,
        //                        StudentId = StudentId,
        //                        TokenNumber = (token != null) ? token.TokenNumber + 1 : 1000
        //                    };
        //                    _appDbContext.StudentToken.Add(newToken);
        //                    _appDbContext.SaveChanges();
        //                    transaction.Commit();
        //                    return newToken;
        //                }
        //            }
        //            catch
        //            {
        //                transaction.Rollback();
        //                return new StudentToken();
        //            }

        //            return new StudentToken();
        //        }
        //    }
        //    else return new StudentToken();
        //}

        public async Task<StudentToken> AddAsync(StudentToken studentToken)
        {
            studentToken.CreatedAt = DateTime.UtcNow;
            studentToken.IsDeleted = false;
            _appDbContext.StudentToken.Add(studentToken);
            await _appDbContext.SaveChangesAsync();
            return studentToken;
        }

        public async Task<StudentToken> UpdateAsync(StudentToken studentToken)
        {
            studentToken.UpdatedAt = DateTime.UtcNow;
            studentToken.IsDeleted = false;
            _appDbContext.StudentToken.Update(studentToken);
            await _appDbContext.SaveChangesAsync();
            return studentToken;
        }
        public async Task<StudentToken> DeleteAsync(int Id)
        {
            var studentToken = await _appDbContext.StudentToken.FindAsync(Id);
            _appDbContext.StudentToken.Remove(studentToken);
            await _appDbContext.SaveChangesAsync();
            return studentToken;
        }
        public async Task<IEnumerable<StudentToken>> GetStudentTokenByStudentIdAsync(int StudentId)
        {
            var studentToken = await (from allStudentToken in _appDbContext.StudentToken
                                      select new StudentToken
                                      {
                                          Id = allStudentToken.Id,
                                          ValidFrom = allStudentToken.ValidFrom,
                                          ValidUpto = allStudentToken.ValidUpto,
                                          TokenFee = allStudentToken.TokenFee,
                                          StudentId = allStudentToken.StudentId,
                                          BatchId = allStudentToken.BatchId,
                                          IsActive = allStudentToken.IsActive,
                                          IsDeleted = allStudentToken.IsDeleted,
                                          CreatedAt = allStudentToken.CreatedAt,
                                          CreatedBy = allStudentToken.CreatedBy,
                                          UpdatedAt = allStudentToken.UpdatedAt,
                                          UpdatedBy = allStudentToken.UpdatedBy,
                                          BatchName = _appDbContext.Batch.Where(b => b.Id == allStudentToken.BatchId).Select(b=>b.BatchName).FirstOrDefault(),
                                      }).OrderByDescending(b=>b.Id).ToListAsync();
            return studentToken;
        }
    }
}
