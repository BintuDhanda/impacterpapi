using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using ERP.SearchFilters;
using ERP.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class StudentTokenRepository:IStudentToken
    {
        private readonly AppDbContext _appDbContext;
        private readonly IConfiguration _configuration;
        public StudentTokenRepository(AppDbContext apDbContext, IConfiguration configuration)
        {
            _appDbContext = apDbContext;
            _configuration = configuration;
        }
        public async Task<IEnumerable<StudentToken>> GetAllAsync()
        {
            return await _appDbContext.StudentToken.ToListAsync();
        }
        public async Task<StudentToken> GetByIdAsync(int Id)
        {
            var studentToken = await _appDbContext.StudentToken.Where(std => std.StudentTokenId == Id).Select(st => new StudentToken
            {
                StudentTokenId = st.StudentTokenId,
                ValidFrom = st.ValidFrom,
                ValidUpto = st.ValidUpto,
                TokenFee = st.TokenFee,
                StudentId = st.StudentId,
                BatchId = st.BatchId,
                IsActive = st.IsActive,
                IsDeleted = st.IsDeleted,
                CreatedAt = st.CreatedAt,
                CreatedBy = st.CreatedBy,
                LastUpdatedAt = st.LastUpdatedAt,
                LastUpdatedBy = st.LastUpdatedBy,
                IsValidForAdmission = st.IsValidForAdmission,
                IsValidForAdmissionNonMapped = st.IsValidForAdmission.ToString(),
            }).FirstOrDefaultAsync();

            return studentToken;
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
            int tokenValidity = _configuration.GetValue<int>("TokenValidity");
            studentToken.ValidFrom = DateTime.UtcNow;
            studentToken.ValidUpto = DateTime.UtcNow.AddDays(tokenValidity);
            studentToken.CreatedAt = DateTime.UtcNow;
            studentToken.IsDeleted = false;
            var studentTokens = await _appDbContext.StudentToken.Where(st =>  st.StudentId == studentToken.StudentId && st.ValidUpto > DateTime.UtcNow && st.BatchId == studentToken.BatchId).FirstOrDefaultAsync();
            if(studentTokens==null)
            {
                _appDbContext.StudentToken.Add(studentToken);
                await _appDbContext.SaveChangesAsync();
                studentToken.Message = "Token Created Successfully!";
            }
            else
            {
                studentToken.Message = "Token Already Exist For This Batch";
            }
            return studentToken;
        }

        public async Task<StudentToken> UpdateAsync(StudentToken studentToken)
        {
            var studentTokens = await _appDbContext.StudentToken.Where(st => st.StudentTokenId == studentToken.StudentTokenId).FirstOrDefaultAsync();
            if ( studentTokens != null)
            {
            studentTokens.LastUpdatedAt = DateTime.UtcNow;
            studentTokens.IsDeleted = false;
            studentTokens.ValidFrom = studentToken.ValidFrom;
            studentTokens.ValidUpto = studentToken.ValidUpto;
            studentTokens.IsValidForAdmission = Convert.ToBoolean(studentToken.IsValidForAdmissionNonMapped);
            studentTokens.TokenFee = studentToken.TokenFee;
            studentTokens.LastUpdatedBy = studentToken.LastUpdatedBy;
            _appDbContext.StudentToken.Update(studentTokens);
            await _appDbContext.SaveChangesAsync();
                return studentToken;
            } 
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
            var studentToken = await  _appDbContext.StudentToken.
                                      Select( st => new StudentToken
                                      {
                                          StudentTokenId = st.StudentTokenId,
                                          ValidFrom = TimeZoneConvert.UtcToIST(st.ValidFrom),
                                          ValidUpto = TimeZoneConvert.UtcToIST(st.ValidUpto),
                                          TokenFee = st.TokenFee,
                                          StudentId = st.StudentId,
                                          BatchId = st.BatchId,
                                          IsActive = st.IsActive,
                                          IsDeleted = st.IsDeleted,
                                          CreatedAt = st.CreatedAt,
                                          CreatedBy = st.CreatedBy,
                                          LastUpdatedAt = st.LastUpdatedAt,
                                          LastUpdatedBy = st.LastUpdatedBy,
                                          BatchName = _appDbContext.Batch.Where(b => b.BatchId == st.BatchId).Select(b=>b.BatchName).FirstOrDefault(),
                                          TokenStatus = _appDbContext.StudentToken.Where(st2 => st2.ValidFrom <= DateTime.UtcNow &&  st2.ValidUpto >=  DateTime.UtcNow ).FirstOrDefault() == null ? false : true,
                                          IsValidForAdmissionNonMapped = st.IsValidForAdmission.ToString(),
                                          TotalDeposit =  _appDbContext.StudentTokenFees.Where(d => d.StudentTokenId == st.StudentTokenId).Sum(s => s.Deposit).ToString(),
                                          TotalRefund =  _appDbContext.StudentTokenFees.Where(d => d.StudentTokenId == st.StudentTokenId).Sum(s => s.Refund).ToString(),
                                      }).Where(t => t.StudentId == StudentId).OrderByDescending(b=>b.StudentTokenId).ToListAsync();
            return studentToken;
        }
    }
}
