using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Index_description :BaseModel
    {
        [Key]
        public long Sno { get; set; }
        public string Headline { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public string TagPercentages { get; set; }
        public bool IsActive { get; set; }

    }
}
