using System;
using System.Collections.Generic;
using System.Text;
using ViewModels.ListModels;
using ViewModels.Models;

namespace Services
{
    public interface ItagServices
    {
        TagListViewModel getAllTags(bool isAdmin);
        TagViewModel getTagsById(bool isAdmin, int id);
        int? AddTag(TagViewModel model);
        int? DeleteTag(int id);
    }
}
