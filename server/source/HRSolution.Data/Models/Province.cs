using System;

namespace HRSolution.Data.Models
{
    public class Province : BaseEntity
    {
        public Guid ProvinceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
