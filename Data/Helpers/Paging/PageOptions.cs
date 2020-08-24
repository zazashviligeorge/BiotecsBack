using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Helpers.Paging
{
    public class PageOptions: RequestParameters
    {
        public int? GroupId { get; set; } // for filtering

        public int? SubstanceId { get; set; } // for filtering

        public string SearchBy { get; set; }

        public string SortBy { get; set; } 
    }

    public abstract class RequestParameters
    {
        const int MaxPageSize = 50;

        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;

        public int PageSize
        {
            get => _pageSize;

            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}
