using System;

namespace HRSolution.Data.Models
{
    public class Photo : BaseEntity
    {
        public Guid PhotoId { get; set; }
        public byte[] Picture { get; set; }
    }
}
