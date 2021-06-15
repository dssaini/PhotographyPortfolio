using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class BaseModel
    {
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
