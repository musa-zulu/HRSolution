using System;

namespace HRSolution.Data.Models
{
    public class Citizenship : BaseEntity
    {
        public Guid CitizenshipId { get; set; }
        public string Description { get; set; }
    }
}
