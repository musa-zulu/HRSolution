using System.Collections.Generic;

namespace HRSolution.Models
{
    public class PaginationResult<T>
    {
        public List<T> Results { get; set; }
        public int PerPage { get; set; }
        public int PageNumber { get; set; }
    }
}