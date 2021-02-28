using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavingPlatformApplication.ViewModels.SavingsGroupViews
{
    public class SavingsGroupSearchResponse
    {
#nullable disable
        public SearchPagination Pagination { get; set; }
        public List<SavingsGroupViewModel> SavingsGroupList { get; set; }
    }
}
