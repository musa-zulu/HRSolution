using System;
using System.Collections.Generic;

namespace HRSolution.Data.Models
{
    public class EmergencyContactDetails
    {
        public Guid EmergencyContactDetailsId { get; set; }
        public string EmergencyContactName { get; set; }
        public long EmergencyContactNumber { get; set; }
        public List<Guid> AddressIds { get; set; }
    }
}
