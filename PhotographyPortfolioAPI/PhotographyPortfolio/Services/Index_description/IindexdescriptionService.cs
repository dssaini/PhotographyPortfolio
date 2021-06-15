using System;
using System.Collections.Generic;
using System.Text;
using ViewModels.ListModels;
using ViewModels.Models;

namespace Services
{
    public interface IindexdescriptionService
    {
        Index_descriptionListViewModel getAllIndex(bool isAdmin);
        Index_descriptionViewModel getIndexById(bool isAdmin, int id);
        int? AddIndex(Index_descriptionViewModel model);
        int? DeleteIndex(int id);
    }
}
