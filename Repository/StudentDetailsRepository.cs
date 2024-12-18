using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using ERP.SearchFilters;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.Bussiness
{
    public class StudentDetailsRepository : IStudentDetails
    {
        private readonly AppDbContext _appDbcontext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public StudentDetailsRepository(AppDbContext appDbcontext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbcontext = appDbcontext;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IEnumerable<StudentDetails>> GetAllAsync(CommonSearchFilter commonSearchFilter)
        {
            var studentDetails = await _appDbcontext.StudentDetails
            .Where(sd => !string.IsNullOrEmpty(commonSearchFilter.Mobile) ? (_appDbcontext.Users.Where(s => s.UsersId == sd.UserId).Select(s => s.UserMobile).FirstOrDefault()) == commonSearchFilter.Mobile : sd.CreatedAt >= Convert.ToDateTime(commonSearchFilter.From).ToUniversalTime() &&
            sd.CreatedAt <= Convert.ToDateTime(commonSearchFilter.To).ToUniversalTime())
            .Select(sd => new StudentDetails
            {
                StudentId = sd.StudentId,
                StudentImage = sd.StudentImage,
                FatherName = sd.FatherName,
                FirstName = sd.FirstName,
                LastName = sd.LastName,
                MotherName = sd.MotherName,
                Gender = sd.Gender,
                BodyRemark = sd.BodyRemark,
                UserId = sd.UserId,
                IsActive = sd.IsActive,
                IsDeleted = sd.IsDeleted,
                CreatedAt = sd.CreatedAt,
                Mobile = _appDbcontext.Users.Where(s => s.UsersId == sd.UserId).Select(s => s.UserMobile).FirstOrDefault(),
                TotalStudent = _appDbcontext.StudentDetails.Where(sd => sd.IsActive == true).Count(),
            })
            .OrderByDescending(o => o.StudentId)
            .Skip(commonSearchFilter.Skip)
            .Take(commonSearchFilter.Take)
            .ToListAsync();
            return studentDetails;
        }
        public async Task<StudentDetails> GetByIdAsync(int Id)
        {
            return await _appDbcontext.StudentDetails.Where(s => s.StudentId == Id).FirstOrDefaultAsync();
        }
        public async Task<StudentDetails> AddAsync(StudentDetails studentDetails)
        {
            var student = await _appDbcontext.StudentDetails.Where(sd => sd.UserId == studentDetails.UserId).FirstOrDefaultAsync();
            if (student == null)
            {
                string filePath = "";
                if (studentDetails.Image != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + studentDetails.Image.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await studentDetails.Image.CopyToAsync(fileStream);
                    }

                    filePath = "/uploads/" + uniqueFileName;
                }
                studentDetails.CreatedAt = DateTime.UtcNow;
                studentDetails.IsDeleted = false;
                _appDbcontext.StudentDetails.Add(studentDetails);
                await _appDbcontext.SaveChangesAsync();
                studentDetails.Message = "Created Sucessfully";
            }
            else
            {
                studentDetails.Message = "Updated Sucessfully";
            }
            return studentDetails;
        }
        public async Task<StudentDetails> UpdateAsync(StudentDetails studentDetails)
        {
            var record = await _appDbcontext.StudentDetails.Where(sd => sd.StudentId == studentDetails.StudentId).FirstOrDefaultAsync();
            string filePath = "";

            if (record != null)
            {
                if (studentDetails.Image != null)
                {
                    var path = "wwwroot" + record.StudentImage;
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }

                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + studentDetails.Image.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await studentDetails.Image.CopyToAsync(fileStream);
                    }
                    filePath = "/uploads/" + uniqueFileName;
                }
                record.StudentImage = filePath;
                record.FirstName = studentDetails.FirstName;
                record.LastName = studentDetails.LastName;
                record.FatherName = studentDetails.FatherName;
                record.MotherName = studentDetails.MotherName;
                record.Gender = studentDetails.Gender;
                record.BodyRemark = studentDetails.BodyRemark;
                record.UserId = studentDetails.UserId;
                record.IsActive = studentDetails.IsActive;
                record.CreatedAt = studentDetails.CreatedAt;
                record.CreatedBy = studentDetails.CreatedBy;
                record.LastUpdatedBy = studentDetails.LastUpdatedBy;
                record.LastUpdatedAt = DateTime.UtcNow;
                record.IsDeleted = false;
                record.IsActive = studentDetails.IsActive;
                _appDbcontext.StudentDetails.Update(record);
                await _appDbcontext.SaveChangesAsync();
            }
            return studentDetails;
        }
        public async Task<StudentDetails> DeleteAsync(int Id)
        {
            var studentDetails = await _appDbcontext.StudentDetails.Where(sd => sd.StudentId == Id).FirstOrDefaultAsync();
            if (studentDetails != null)
            {
                var path = "wwwroot" + studentDetails.StudentImage;
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                _appDbcontext.StudentDetails.Remove(studentDetails);
                await _appDbcontext.SaveChangesAsync();
            }
            return studentDetails;
        }
        public async Task<StudentDetails> GetStudentDetailsByUserIdAsync(int UserId)
        {
            return await _appDbcontext.StudentDetails.Where(s => s.UserId == UserId).FirstOrDefaultAsync();
        }
        public async Task<IActionResult> GetStudentIdByRegistrationNumber(string RegistrationNumber)
        {
            return new JsonResult(await _appDbcontext.StudentBatch.Where(x => x.RegistrationNumber == RegistrationNumber).Select(sd => new { sd.StudentId }).FirstOrDefaultAsync());
        }
    }
}
