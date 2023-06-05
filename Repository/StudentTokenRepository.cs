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
        public async Task<StudentToken> AddAsync(int UserId, int BatchId)
        {
            var record = await _appDbContext.StudentToken.Where(u => u.UserId == UserId && u.BatchId == BatchId).FirstOrDefaultAsync();
            if (record == null)
            {
                var tokenValidity = await _appDbContext.TokenValidity.Where(b => b.BatchId == BatchId).FirstOrDefaultAsync();
                using (var transaction = await _appDbContext.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var token = await _appDbContext.StudentToken.OrderByDescending(s => s.Id).FirstOrDefaultAsync();
                        if (token != null && tokenValidity != null)
                        {
                            var newToken = new StudentToken()
                            {
                                Amount = tokenValidity.Amount,
                                ValidForm = System.DateTime.UtcNow,
                                ValidUpto = System.DateTime.UtcNow.AddDays(tokenValidity.Validity),
                                BatchId = BatchId,
                                UserId = UserId,
                                TokenNumber = (token != null) ? token.TokenNumber + 1 : 1000
                            };
                            _appDbContext.StudentToken.Add(newToken);
                            _appDbContext.SaveChanges();
                            transaction.Commit();
                            return newToken;
                        }
                    }
                    catch
                    {
                        transaction.Rollback();
                        return new StudentToken();
                    }

                    return new StudentToken();
                }
            }
            else return new StudentToken();
        }
                
        public async Task<StudentToken> UpdateAsync(StudentToken studentToken)
        {
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
    }
}
