using ClosedXML.Excel;
using DocumentFormat.OpenXml.InkML;
using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using ERP.SearchFilters;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace ERP.Bussiness
{
    public  class UserRepository : IUser
    {
        public IConfiguration _configration;
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UserRepository(AppDbContext appDbContext,IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = appDbContext;
            _configration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IEnumerable<Users>> GetAllAsync(CommonSearchFilter commonSearchFilter)
        {
            var users = await _dbContext.Users
                        .Where (u => !string.IsNullOrEmpty(commonSearchFilter.Mobile) ? u.UserMobile==commonSearchFilter.Mobile : u.CreatedAt >= Convert.ToDateTime(commonSearchFilter.From).ToUniversalTime() &&
                         u.CreatedAt <= Convert.ToDateTime(commonSearchFilter.To).ToUniversalTime())
                        .Select( u =>  new Users
                        {
                            UsersId = u.UsersId,
                            UserEmail = u.UserEmail,
                            UserMobile = u.UserMobile,
                            UserPassword = u.UserPassword,
                            IsEmailConfirmed = u.IsEmailConfirmed,
                            IsMobileConfirmed = u.IsMobileConfirmed,
                            IsActive = u.IsActive,
                            IsDeleted = u.IsDeleted,
                            CreatedAt = u.CreatedAt,
                            CreatedBy = u.CreatedBy,
                            LastUpdatedAt = u.LastUpdatedAt,
                            LastUpdatedBy = u.LastUpdatedBy,
                            IsStudentCreated = _dbContext.StudentDetails.Where(f=>f.UserId==u.UsersId).FirstOrDefault() == null ? false:true,
                            TotalUser = _dbContext.Users.Where(u=>u.IsActive == true).Count(),
                        })
                        .OrderByDescending(o=>o.UsersId)
                        .Skip(commonSearchFilter.Skip) 
                        .Take(commonSearchFilter.Take)
                        .ToListAsync();
            return users;
        }

        public async Task<Users> GetByIdAsync(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<Users> AddAsync(Users user)
        {
            user.CreatedAt = DateTime.UtcNow;
            user.IsDeleted = false;
            user.IsEmailConfirmed = false;
            
            var users = await _dbContext.Users.Where(x=> x.UserMobile == user.UserMobile).FirstOrDefaultAsync();
            if (users == null)
            {
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
                return user;
            }

            return new Users();
        }

        public async Task<Users> UpdateAsync(Users user)
        {
            var users = await _dbContext.Users.Where(x => x.UserEmail == ((string.IsNullOrEmpty(user.UserEmail)) ? "" : user.UserEmail) || x.UserMobile == user.UserMobile).FirstOrDefaultAsync();
            if (users != null)
            {
                users.LastUpdatedAt = DateTime.UtcNow;
                users.IsDeleted = false;
                users.UserMobile = user.UserMobile;
                users.LastUpdatedBy = user.LastUpdatedBy;
                _dbContext.Users.Update(users);
                await _dbContext.SaveChangesAsync();
                return users;
            }
            return user;
        }

        public async Task<Users> DeleteAsync(int Id)
        {
            var user = await  _dbContext.Users.FindAsync(Id);
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<UserRole> AddUserToRole(Users user)
        {
            if (user.UsersId == 0) return new UserRole();
            else
            {
                var roleId = await _dbContext.Roles.Where(r => r.RoleName == "Student").Select(s => s.RolesId).FirstOrDefaultAsync();
                var userRole = new UserRole()
                {
                    RoleID = roleId,
                    UserID = user.UsersId
                };
                _dbContext.UserRole.Add(userRole);
                await _dbContext.SaveChangesAsync();
                return userRole;
            }
        }
        public async Task<UserSignUpResponse> SignUpAsync(Users user)
        {
            var response = new UserSignUpResponse();
            var newUser = AddAsync(user).Result;
            var userRole = AddUserToRole(newUser).Result;
            if(userRole != null)
            {
                response = GenerateJWT(newUser);
            }
            return response;
        }

        public async Task<IEnumerable<Users>> SearchAsync(UserSearch userSearch)
        {
            int currentPage = userSearch.CurrentPage;
            int recordsPerPage = userSearch.Take;
            int skip = userSearch.CurrentPage==1? 0: (userSearch.CurrentPage-1)*userSearch.Take;


            var count =  await _dbContext.Users.Where(w =>
               
               (string.IsNullOrEmpty(userSearch.UserMobile) || w.UserMobile.Contains(userSearch.UserMobile))
               && (string.IsNullOrEmpty(userSearch.IsActive) || w.IsActive == Convert.ToBoolean(userSearch.IsActive))
               && (string.IsNullOrEmpty(userSearch.From) && string.IsNullOrEmpty(userSearch.To) && !w.CreatedAt.HasValue) || w.CreatedAt.Value.Date >= Convert.ToDateTime(userSearch.From) || w.CreatedAt <= Convert.ToDateTime(userSearch.To)
               ).Select(s=>s.UsersId).CountAsync(); 

            var users = await _dbContext.Users.Where(w =>
                (string.IsNullOrEmpty(userSearch.UserMobile) || w.UserMobile.Contains(userSearch.UserMobile))
               && (string.IsNullOrEmpty(userSearch.IsActive)||w.IsActive == Convert.ToBoolean(userSearch.IsActive))
               && (string.IsNullOrEmpty(userSearch.From) && string.IsNullOrEmpty(userSearch.To) && !w.CreatedAt.HasValue ) ||  w.CreatedAt.Value.Date >= Convert.ToDateTime(userSearch.From) || w.CreatedAt <= Convert.ToDateTime(userSearch.To)
               ).Take(userSearch.Take).
               Skip(skip)
               .Select(s=>new Users
               {    
                    CreatedAt = s.CreatedAt.HasValue?s.CreatedAt.Value.Date: null,
                     UsersId =s.UsersId,
                      IsActive=s.IsActive.HasValue?s.IsActive.Value: null,
                      UserMobile=s.UserMobile,
                      UserPassword= "",
                      TotalCount=count
               }).
               ToListAsync();

            return users;
        }

        public async Task<UserSignUpResponse> UserLogInAsync(UserLogin userLogin)
        {
            var userRecord = await _dbContext.Users.Where(x=>x.UserMobile == userLogin.UserMobile && x.UserPassword == userLogin.UserPassword).FirstOrDefaultAsync();
            var userIsStudent = await _dbContext.Roles.Where(w => w.RolesId == (_dbContext.UserRole.Where(u => u.UserID == ( userRecord == null ? 0 : userRecord.UsersId)).Select(s => s.RoleID).FirstOrDefault())).Select(r=>r.RoleName).ToListAsync();
            if (userRecord!=null && userIsStudent.Contains("Student"))
            {
            var response = GenerateJWT(userRecord);
            return response;
            }
            else
            {
                return new UserSignUpResponse();
            }
        }
        public async Task<UserSignUpResponse> ERPLogInAsync(UserLogin userLogin)
        {
            var userRecord = await _dbContext.Users.Where(x=>x.UserMobile == userLogin.UserMobile && x.UserPassword == userLogin.UserPassword).FirstOrDefaultAsync();
            var userIsStudent = await _dbContext.Roles.Where(w => w.RolesId == (_dbContext.UserRole.Where(u => u.UserID == (userRecord == null?0:userRecord.UsersId)).Select(s => s.RoleID).FirstOrDefault())).Select(r => r.RoleName).ToListAsync();
            if (userRecord!=null && userIsStudent.Contains("Admin") || userIsStudent.Contains("Staff"))
            {
            var response = GenerateJWT(userRecord);
            return response;
            }
            else
            {
                return new UserSignUpResponse();
            }
        }

        public async Task<IActionResult> IsExists(CommonSearchFilter commonSearchFilter)
        {
            return new JsonResult(await _dbContext.Users.AnyAsync(x => x.UserMobile == commonSearchFilter.Mobile));
        }
        public async Task<IActionResult> GetStudentIdByUserId(int UserId)
        {
            return new JsonResult(await _dbContext.StudentDetails.Where(x => x.UserId == UserId).Select(sd => new { sd.StudentId }).FirstOrDefaultAsync());
        }
        public async Task<IActionResult> IsVerified(string userMobile)
        {
            return new JsonResult(await _dbContext.Users.Where(x => x.UserMobile == userMobile).Select(s=>s.IsMobileConfirmed).FirstOrDefaultAsync());
        }
        public async Task<IActionResult> IsMobileConfirmed(string userMobile)
        {
            var record = await _dbContext.Users.Where(w => w.UserMobile == userMobile).FirstOrDefaultAsync();
            record.IsMobileConfirmed = true;
            _dbContext.Users.Update(record);
            await _dbContext.SaveChangesAsync();
            return new JsonResult("true");
        }
        public async Task<IActionResult> ForgotPassword(ForgotPassword forgotPassword)
        {
            var record = await _dbContext.Users.Where(w => w.UserMobile == forgotPassword.Mobile).FirstOrDefaultAsync();
            record.UserPassword = forgotPassword.Password;
            _dbContext.Users.Update(record);
            await _dbContext.SaveChangesAsync();
            return new JsonResult("true");
        }

        private UserSignUpResponse GenerateJWT(Users user)
        {
            var roleList = string.Join(',',(from ur in _dbContext.UserRole join
                           r in _dbContext.Roles on ur.RoleID equals r.RolesId
                           where ur.UserID == user.UsersId
                           select r.RoleName));

            var issuer = _configration["Jwt:Issuer"];
            var audience = _configration["Jwt:Audience"];
            var key = Encoding.ASCII.GetBytes(_configration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("UsersId", user.UsersId.ToString()),
                    new Claim("UserMobile", user.UserMobile),
                    new Claim(ClaimTypes.Role, roleList),
             }),
                Expires = DateTime.UtcNow.AddDays(30),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            var stringToken = tokenHandler.WriteToken(token);

            var userSignUpResponse = new UserSignUpResponse()
            {
                Message = "success",
                Token = jwtToken,
                UserId = user.UsersId,
            };

            return userSignUpResponse;
        }
        public async Task<IActionResult> BulkUserUpload(FileUpload fileUpload)
        {
            var user = _dbContext.Users.Where(u => u.UserMobile == fileUpload.UserMobile && u.UserPassword == fileUpload.UserPassword).FirstOrDefault();

            if(user == null)
            {
                return new JsonResult("User Does Not Exists");
            }
            else
            {
                if (fileUpload.UploadFile == null || fileUpload.UploadFile.Length <= 0)
                {
                    return new JsonResult("No file uploaded.");
                }

                if (!Path.GetExtension(fileUpload.UploadFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    return new JsonResult("Invalid file format. Only .xlsx files are allowed.");
                }

                try
                {
                    using (var workbook = new XLWorkbook(fileUpload.UploadFile.OpenReadStream()))
                    {
                        var worksheet = workbook.Worksheet(1); // Assuming the data is in the first worksheet

                        var rows = worksheet.RowsUsed().Skip(1); // Skip the header row
                       
                        var columnNames = new Dictionary<string, int>();

                        // Read the column names from the header row
                        var headerRow = worksheet.FirstRow();
                       
                        foreach (var cell in headerRow.Cells())
                        {
                            var columnName = cell.Value.ToString();
                            var columnIndex = cell.Address.ColumnNumber;
                            columnNames[columnName] = columnIndex;
                        }

                        foreach (var row in rows)
                        {
                            // Assuming your database entity has properties like "Column1", "Column2", etc.
                            var entity = new Users
                            {
                                UserMobile = row.Cell(columnNames["UserMobile"]).Value.ToString(),
                                UserPassword = row.Cell(columnNames["UserPassword"]).Value.ToString(),
                                CreatedAt = System.DateTime.UtcNow,
                                CreatedBy = user.UsersId,
                                LastUpdatedAt = System.DateTime.UtcNow,
                                LastUpdatedBy = user.UsersId,
                                IsActive = true,
                                IsDeleted = false,
                                IsMobileConfirmed=false,
                                IsEmailConfirmed=false,
                                UserEmail="",
                            };

                            var uploadStatusCell = row.Cell(columnNames["UploadStatus"]);

                            if (entity.UserMobile.Length > 10)
                            {
                                uploadStatusCell.Value = "Invalid mobile number";
                            }
                            else if (!Regex.IsMatch(entity.UserMobile, @"^\d+$"))
                            {
                                uploadStatusCell.Value = "Invalid mobile number format";
                            }
                            else if (entity.UserPassword.Length < 5)
                            {
                                uploadStatusCell.Value = "Invalid password length";
                            }
                            else
                            {
                                if(_dbContext.Users.Any(i => i.UserMobile == entity.UserMobile))
                                {
                                    uploadStatusCell.Value = "Already Exists";
                                }
                                else
                                {
                                    _dbContext.Users.Add(entity);
                                    _dbContext.SaveChanges();
                                    uploadStatusCell.Value = "Successfully imported";
                                }
                            }
                            
                        }

                        // Save the modified workbook to a new file
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "temp");
                        
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        var updatedFilePath = Path.Combine(uploadsFolder, "updated_data.xlsx");
                        workbook.SaveAs(updatedFilePath);

                        // Return the updated Excel file for download
                        var fileStream = new FileStream(updatedFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                        return new FileStreamResult(fileStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                        {
                            FileDownloadName = "updated_data.xlsx"
                        };
                    }
                  
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during the process
                    return new JsonResult(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
                }
            }
        }

    }

}
