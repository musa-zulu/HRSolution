using System;
using System.Collections.Generic;

namespace HRSolution.Data.Models
{
    public class EmergencyContactDetails : BaseEntity
    {
        public Guid EmergencyContactDetailsId { get; set; }
        public string EmergencyContactName { get; set; }
        public long EmergencyContactNumber { get; set; }
        public virtual List<Address> Addresses { get; set; }
    }
}
