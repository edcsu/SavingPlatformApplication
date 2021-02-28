using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SavingPlatformApplication.ViewModels
{
    public class SearchRequest
    {
        public SearchRequest()
        {
            Pagination = new SearchViewPagination
            {
                ItemsPerPage = 50,
                Page = 1
            };
        }

        public SearchViewPagination Pagination { get; set; }
    }
}
