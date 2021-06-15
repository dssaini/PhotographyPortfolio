using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Carousel :BaseModel
    {
        [Key]
        public long Sno { get; set; }
        public string PhotoName { get; set; }
        public int SliderNo { get; set; }
        public string ThumbnailPath { get; set; }
        public string PhotoPath { get; set; }
        public bool IsActive { get; set; }

    }
}
