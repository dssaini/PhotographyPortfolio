using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Tags :BaseModel
    {
        [Key]
        public long Sno { get; set; }
        public string PhotoTags { get; set; }
    }
}
