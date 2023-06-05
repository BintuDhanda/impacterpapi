using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class StudentQualificationRepository:IStudentQualification
    {
        private readonly AppDbContext _appDbContext;
        public StudentQualificationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<StudentQualification>> GetAllAsync()
        {
            return await _appDbContext.StudentQualification.ToListAsync();
        }
        public async Task<StudentQualification> GetByIdAsync(int Id)
        {
            return await _appDbContext.StudentQualification.FindAsync(Id);
        }
        public async Task<StudentQualification> AddAsync(StudentQualification studentQualification)
        {
            _appDbContext.StudentQualification.Add(studentQualification);
            await _appDbContext.SaveChangesAsync();
            return studentQualification;
        }
        public async Task<StudentQualification> UpdateAsync(StudentQualification studentQualification)
        {
            _appDbContext.StudentQualification.Update(studentQualification);
            await _appDbContext.SaveChangesAsync();
            return studentQualification;
        }
        public async Task<StudentQualification> DeleteAsync(int Id)
        {
            var studentQualification = await _appDbContext.StudentQualification.FindAsync(Id);
            _appDbContext.Remove(studentQualification);
            await _appDbContext.SaveChangesAsync();
            return studentQualification;
        }
        public async Task<IEnumerable<StudentQualification>> GetQualificationNameAsync (int Id)
        {
            var studentQualification = await (from allStudentQualification in _appDbContext.StudentQualification
                                              join qualification in _appDbContext.Qualification on allStudentQualification.QualificationId equals qualification.Id
                                              where allStudentQualification.UserId == Id
                                              select new StudentQualification
                                              { 
                                                Id = allStudentQualification.Id,
                                                Subjects = allStudentQualification.Subjects,
                                                MarksObtain = allStudentQualification.MarksObtain,
                                                MaximumMarks = allStudentQualification.MaximumMarks,
                                                Percentage = allStudentQualification.Percentage,
                                                Grade = allStudentQualification.Grade,
                                                QualificationId = allStudentQualification.QualificationId,
                                                QualificationName = qualification.QualificationName,
                                                IsActive= allStudentQualification.IsActive,
                                                UserId = allStudentQualification.UserId
                                              }).ToListAsync();
            return studentQualification;
        } 
    }
}
