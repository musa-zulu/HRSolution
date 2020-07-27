using System;

namespace HRSolution.Data.Models
{
    public class DisabledType : BaseEntity
    {
        public Guid DisabledTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
