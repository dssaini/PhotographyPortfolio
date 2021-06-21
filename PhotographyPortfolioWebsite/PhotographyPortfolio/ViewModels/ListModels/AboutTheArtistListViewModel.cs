using System;
using System.Collections.Generic;
using System.Text;
using ViewModels.Models;

namespace ViewModels.ListModels
{
    public class AboutTheArtistListViewModel :BaseViewModel
    {
        public List<AboutTheArtistViewModel> AboutTheArtists { get; set; }
    }
}
