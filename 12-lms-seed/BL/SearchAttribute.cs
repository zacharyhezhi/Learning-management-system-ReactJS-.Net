using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SearchAttribute
    {
        public string SortString { get; set; }
        public string SortOrder { get; set; }
        public string SearchValue { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
