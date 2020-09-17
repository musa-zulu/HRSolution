using System;

namespace HRSolution.Data.Models
{
    public class Race : BaseEntity
    {
        public Guid RaceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
