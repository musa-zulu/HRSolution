using System;

namespace HRSolution.Data.Models
{
    public class Status : BaseEntity
    {
        public Guid StatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
