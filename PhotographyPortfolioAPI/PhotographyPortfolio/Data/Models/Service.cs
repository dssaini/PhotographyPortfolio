using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Service: BaseModel
    {
        [Key]
        public long Sno { get; set; }
        public string Headline { get; set; }
        public string Description { get; set; }
        public string IconImagePath { get; set; }
        public bool IsActive { get; set; }

    }
}
