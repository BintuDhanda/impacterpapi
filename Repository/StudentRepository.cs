using ERP.ERPDbContext;
using ERP.Interface;
using ERP.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace ERP.Bussiness
{
    public class StudentRepository:IStudent
    {
        private readonly AppDbContext _appDbContext;
        public StudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _appDbContext.Student.ToListAsync();
        }
        public async Task<Student> GetByIdAsync (int Id)
        {
            return await _appDbContext.Student.FindAsync(Id);
        }
        //private void CreatePasswordHash(string password,out byte[] passwor)
        //{
        //    using (var hmac = new System.Security.Cryptography.HMACSHA512())
        //    {
        //        passwor = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //    }
        //}
        //public static string EncryptPassword(string password)
        //{
        //    using var sha256 = SHA256.Create();
        //    byte[] bytes = Encoding.UTF8.GetBytes(password);
        //    byte[] hash = sha256.ComputeHash(bytes);
        //    return Convert.ToBase64String(hash);
        //}
        public static string EncryptPassword(string password)
        {
            using var aes = Aes.Create();
            aes.GenerateKey();
            byte[] key = aes.Key;

            byte[] encryptedBytes;
            using (var encryptor = aes.CreateEncryptor(key, aes.IV))
            {
                byte[] plainBytes = Encoding.UTF8.GetBytes(password);
                encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
            }

            byte[] combinedBytes = new byte[aes.IV.Length + encryptedBytes.Length];
            Array.Copy(aes.IV, 0, combinedBytes, 0, aes.IV.Length);
            Array.Copy(encryptedBytes, 0, combinedBytes, aes.IV.Length, encryptedBytes.Length);

            return Convert.ToBase64String(combinedBytes);
        }
        public static string DecryptPassword(string encryptedPassword)
        {
            byte[] combinedBytes = Convert.FromBase64String(encryptedPassword);
            byte[] iv = new byte[16];
            byte[] encryptedBytes = new byte[combinedBytes.Length - iv.Length];
            Array.Copy(combinedBytes, iv, iv.Length);
            Array.Copy(combinedBytes, iv.Length, encryptedBytes, 0, encryptedBytes.Length);

            using var aes = Aes.Create();
            byte[] key = aes.Key;
            using var decryptor = aes.CreateDecryptor(key, iv);
            byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

            return Encoding.UTF8.GetString(decryptedBytes);
        }
        public async Task<Student> AddAsync(Student student)
        {
            //byte[] passwor;
            //CreatePasswordHash(student.StudentPassword, out passwor);
            ////student.StudentPassword = passwor;
            string encryptedPassword = EncryptPassword(student.StudentPassword);
            //string decryptPassword = DecryptPassword(encryptedPassword);
            student.StudentPassword = encryptedPassword;
            student.CreatedAt = System.DateTime.UtcNow;
            student.IsDeleted = false;
            _appDbContext.Student.Add(student);
            await _appDbContext.SaveChangesAsync();
            return student;
        }
        public async Task<Student> UpdateAsync(Student student)
        {
            _appDbContext.Student.Update(student);
            await _appDbContext.SaveChangesAsync();
            return student;
        }
        public async Task<Student> DeleteAsync(int Id)
        {
            var student = await _appDbContext.Student.FindAsync(Id);
            _appDbContext.Student.Remove(student);
            await _appDbContext.SaveChangesAsync();
            return student;
        }
    }
}
