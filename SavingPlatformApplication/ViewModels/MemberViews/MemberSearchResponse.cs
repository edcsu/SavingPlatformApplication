using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavingPlatformApplication.ViewModels.MemberViews
{
    public class MemberSearchResponse
    {
#nullable disable
        public SearchPagination Pagination { get; set; }
        public List<MemberViewModel> MembersList { get; set; }
    }
}
