using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class StudentFeesRepository:IStudentFees
    {
        private readonly AppDbContext _appDbcontext;
        public StudentFeesRepository(AppDbContext appDbContext)
        {
            _appDbcontext = appDbContext;
        }
        public async Task<IEnumerable<StudentFees>> GetAllAsync()
        {
            return await _appDbcontext.StudentFees.ToListAsync();
        }
        public async Task<StudentFees> GetByIdAsync(int Id)
        {
            return await _appDbcontext.StudentFees.FindAsync(Id);
        }
        public async Task<StudentFees> AddAsync(StudentFees studentFees)
        {
            _appDbcontext.StudentFees.Add(studentFees);
            await _appDbcontext.SaveChangesAsync();
            return studentFees;
        }
        public async Task<StudentFees> UpdateAsync(StudentFees studentFees)
        {
            _appDbcontext.StudentFees.Update(studentFees);
            await _appDbcontext.SaveChangesAsync();
            return studentFees;
        }
        public async Task<StudentFees> DeleteAsync(int Id)
        {
            var studentFees = await _appDbcontext.StudentFees.FindAsync(Id);
            _appDbcontext.StudentFees.Remove(studentFees);
            await _appDbcontext.SaveChangesAsync();
            return studentFees;
        }
    }
}
