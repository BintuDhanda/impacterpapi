using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class StudentContactRepository:IStudentContact
    {
        private readonly AppDbContext _appDbcontext;
        public StudentContactRepository(AppDbContext appDbcontext)
        {
            _appDbcontext = appDbcontext;
        }
        public async Task<IEnumerable<StudentContact>> GetAllAsync()
        {
            return await _appDbcontext.StudentContact.ToListAsync();
        }
        public async Task<StudentContact> GetByIdAsync(int Id)
        {
            return await _appDbcontext.StudentContact.FindAsync(Id);
        }
        public async Task<StudentContact> AddAsync(StudentContact studentContact)
        {
            _appDbcontext.StudentContact.Add(studentContact);
            await _appDbcontext.SaveChangesAsync();
            return studentContact;
        }
        public async Task<StudentContact> UpdateAsync(StudentContact studentContact)
        {
            _appDbcontext.StudentContact.Update(studentContact);
            await _appDbcontext.SaveChangesAsync();
            return studentContact;
        }
        public async Task<StudentContact> DeleteAsync(int Id)
        {
            var studentContact = await _appDbcontext.StudentContact.FindAsync(Id);
            _appDbcontext.StudentContact.Remove(studentContact);
            await _appDbcontext.SaveChangesAsync();
            return studentContact;
        }
    }
}
