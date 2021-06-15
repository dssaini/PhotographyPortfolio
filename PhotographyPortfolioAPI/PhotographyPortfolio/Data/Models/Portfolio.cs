using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Portfolio: BaseModel
    {
        [Key]
        public long Sno { get; set; }
        public string PhotoName { get; set; }
        public string ThumbnailPath { get; set; }
        public string PhotoPath { get; set; }
        public bool IsActive { get; set; }
        public string Tags { get; set; }
    }
}
