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
        public Guid LanguageId { get; set; }
        public Guid RaceId { get; set; }   
        public Guid CitizenshipId { get; set; }
        public Guid DisabledTypeId { get; set; }
        public Guid MaritialStatusId { get; set; }
        public Guid AttachmentId { get; set; }
        public Guid ContactDetailsId { get; set; }
        public List<Guid> AddressIds { get; set; }
    }
}
