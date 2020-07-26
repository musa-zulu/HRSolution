using System;

namespace HRSolution.Data.Models
{
    public class Address : BaseEntity
    {
        public Guid AddressId { get; set; }
        public string AddressType { get; set; } 
        public int UnitNumber { get; set; }
        public string ComplexName { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string SuburbOrDistrict { get; set; }
        public string CityOrTown { get; set; }
        public int Code { get; set; }
        public string Country { get; set; }
        public bool IsPhysicalAddressSameAsPostal { get; set; }
        public Guid ProvinceId { get; set; }
    }
}
