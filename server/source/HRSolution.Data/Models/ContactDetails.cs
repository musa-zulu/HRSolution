using System;
using System.Collections.Generic;

namespace HRSolution.Data.Models
{
    public class ContactDetails : BaseEntity
    {
        public Guid ContactDetailsId { get; set; }
        public long HomeNumber { get; set; }
        public long WorkNumber { get; set; }
        public long WorkExtension { get; set; }
        public long CellphoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public virtual List<EmergencyContactDetails> EmergencyContactDetails { get; set; }
    }
}
