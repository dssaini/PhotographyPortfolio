using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Models
{
    public class AboutTheArtistViewModel :BaseViewModel
    {
        public string Headline { get; set; }
        public string Description { get; set; }
        public string ArtistPhoto { get; set; }
        public bool IsActive { get; set; }
    }
}
