using System;
using System.Collections.Generic;

namespace HRSolution.Data.Models
{
    public class Person : BaseEntity
    {
        public Guid PersonId { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public bool ForeignNational { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid EmployeeDetailsId { get; set; }
        public virtual EmployeeDetails EmployeeDetails { get; set; }
        public Guid LanguageId { get; set; }
        public virtual Language Language { get; set; }
        public Guid RaceId { get; set; }
        public virtual Race Race { get; set; }
        public Guid CitizenshipId { get; set; }
        public virtual Citizenship Citizenship { get; set; }
        public Guid DisabledTypeId { get; set; }
        public virtual DisabledType DisabledType { get; set; }
        public Guid MaritialStatusId { get; set; }
        public virtual MaritialStatus MaritialStatus { get; set; }
        public Guid AttachmentId { get; set; }
        public virtual Attachment Attachment { get; set; }
        public Guid ContactDetailsId { get; set; }
        public virtual ContactDetails ContactDetails { get; set; }
        public virtual List<Address> Addresses { get; set; }
    }
}
