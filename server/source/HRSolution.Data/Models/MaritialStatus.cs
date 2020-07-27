using System;

namespace HRSolution.Data.Models
{
    public class MaritialStatus : BaseEntity
    {
        public Guid MaritialStatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
