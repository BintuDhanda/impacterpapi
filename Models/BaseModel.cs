﻿namespace ERP.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            IsActive = true;
            IsDeleted = false;
            CreatedAt = DateTime.Now;
        }
        public DateTime? CreatedAt { get; set; } = System.DateTime.UtcNow;
        public int? CreatedBy { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public int? LastUpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
