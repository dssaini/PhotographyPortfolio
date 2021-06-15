using System;
using System.Collections.Generic;
using System.Text;
using ViewModels.ListModels;
using ViewModels.Models;

namespace Services
{
    public interface IArtistServices
    {
        AboutTheArtistListViewModel getAllArtist(bool isAdmin);
        AboutTheArtistViewModel getArtistById(bool isAdmin, int id);
        int? AddArtist(AboutTheArtistViewModel model);
        int? DeleteArtist(int id);
    }
}
