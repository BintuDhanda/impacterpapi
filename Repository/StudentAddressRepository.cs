using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class StudentAddressRepository:IStudentAddress
    {
        private readonly AppDbContext _appDbcontext;
        public StudentAddressRepository(AppDbContext appDbcontext)
        {
            _appDbcontext = appDbcontext;
        }
        public async Task<IEnumerable<StudentAddress>> GetAllAsync()
        {
            return await _appDbcontext.StudentAddress.ToListAsync();
        }
        public async Task<StudentAddress> GetByIdAsync(int Id)
        {
            return await _appDbcontext.StudentAddress.FindAsync(Id);
        }
        public async Task<StudentAddress> AddAsync(StudentAddress studentAddress)
        {
            studentAddress.CreatedAt = DateTime.UtcNow;
            studentAddress.IsDeleted = false;
            _appDbcontext.StudentAddress.Add(studentAddress);
            await _appDbcontext.SaveChangesAsync();
            return studentAddress;
        }
        public async Task<StudentAddress> UpdateAsync(StudentAddress studentAddress)
        {
            studentAddress.UpdatedAt = DateTime.UtcNow;
            studentAddress.IsDeleted = false;
            _appDbcontext.StudentAddress.Update(studentAddress);
            await _appDbcontext.SaveChangesAsync();
            return studentAddress;
        }
        public async Task<StudentAddress> DeleteAsync(int Id)
        {
            var studentAddress = await _appDbcontext.StudentAddress.FindAsync(Id);
            _appDbcontext.StudentAddress.Remove(studentAddress);
            await _appDbcontext.SaveChangesAsync();
            return studentAddress;
        }
        public async Task<IEnumerable<StudentAddress>> GetStudentAddressByStudentIdAsync(int Id)
        {
            var studentAddress = await (from allStudentAddress in _appDbcontext.StudentAddress
                                 join addressType in _appDbcontext.AddressType on allStudentAddress.AddressTypeId equals addressType.Id
                                 join country in _appDbcontext.Country on allStudentAddress.CountryId equals country.Id
                                 join state in _appDbcontext.State on allStudentAddress.StateId equals state.Id
                                 join city in _appDbcontext.City on allStudentAddress.CityId equals city.ID
                                 where allStudentAddress.StudentId == Id
                                 select new StudentAddress
                                 {
                                     Id = allStudentAddress.Id,
                                     AddressTypeId = allStudentAddress.AddressTypeId,
                                     AddressType= addressType.AddressTypeName,
                                     Address = allStudentAddress.Address,
                                     CountryId = allStudentAddress.CountryId,
                                     Country = country.CountryName,
                                     StateId = allStudentAddress.StateId,
                                     State = state.StateName,
                                     CityId = allStudentAddress.CityId,
                                     City = city.CityName,
                                     Pincode = allStudentAddress.Pincode,
                                     IsActive = allStudentAddress.IsActive,
                                     StudentId = allStudentAddress.StudentId,
                                     CreatedAt = allStudentAddress.CreatedAt,
                                     CreatedBy = allStudentAddress.CreatedBy,
                                     UpdatedAt = allStudentAddress.UpdatedAt,
                                     UpdatedBy = allStudentAddress.UpdatedBy,
                                 }).ToListAsync();
            return studentAddress;
        }
    }
}
