using System;

namespace HRSolution.Data.Models
{
    public class EmployeeDetails
    {
        public Guid EmployeeDetailsId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeNumber { get; set; }
        public string MiddleName { get; set; }
        public string Initials { get; set; }
        public string PreferredName { get; set; }
        public string MaidenName { get; set; }
        public string Title { get; set; }
        public string IdNumber { get; set; }
        public bool EmployeeRetired { get; set; }
    }
}
