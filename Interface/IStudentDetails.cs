﻿using ERP.Models;

namespace ERP.Interface
{
    public interface IStudentDetails
    {
        Task<IEnumerable<StudentDetails>> GetAllAsync();
        Task<StudentDetails> GetByIdAsync(int Id);
        Task<StudentDetails> AddAsync(StudentDetails studentDetails);
        Task<StudentDetails> UpdateAsync(StudentDetails studentDetails);
        Task<StudentDetails> DeleteAsync(int Id);
    }
}