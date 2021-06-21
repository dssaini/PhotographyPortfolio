using System;
using System.Collections.Generic;
using System.Text;
using ViewModels.Models;

namespace ViewModels.ListModels
{
    public class TagListViewModel :BaseViewModel
    {
        public List<TagViewModel> Tags { get; set; }
    }
}
