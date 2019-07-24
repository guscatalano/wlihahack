using System;
using System.Runtime.Serialization;

namespace WlihaHackEviction.Models
{
    [DataContract]
    public class TenantInfo
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public int NumberOfPpl { get; set; }
        [DataMember]
        public int AddressId { get; set; }
    }

    [DataContract]
    public class AddressInfo
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string StreetAddress { get; set; }
        [DataMember]
        public int Unit { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string County { get; set; }
        [DataMember]
        public int ZipCode { get; set; }
        [DataMember]
        public float Latitude { get; set; }
        [DataMember]
        public float Longitude { get; set; }
    }

    [DataContract]
    public class EvictionInfo
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime DateOfEviction { get; set; }
    }

    [DataContract]
    public class PermitInfo
    {
        [DataMember]
       public string PermitNum { get; set; }
       public string PermitClass { get; set; }
       public string PermitClassMapped { get; set; }
       public string PermitTypeMapped { get; set; }
       public string PermitTypeDesc{ get; set; }
       public string Description { get; set; }
       public int HousingUnits{ get; set; }
       public int HousingUnitsRemoved { get; set; }
       public int HousingUnitsAdded { get; set; }
       public float EstProjectCost { get; set; }
       public DateTime AppliedDate { get; set; }
       public DateTime IssuedDate { get; set; }
       public DateTime ExpiresDate { get; set; }
       public DateTime CompletedDate { get; set; }
       public string StatusCurrent { get; set; }
       public string OriginalAddress1 { get; set; }
       public string OriginalCity { get; set; }
       public string OriginalState { get; set; }
       public int OriginalZip { get; set; }
       public string ContractorCompanyName { get; set; }
       public string Link { get; set; }
       public float Latitude { get; set; }
       public float Longitude { get; set; }
       public string Location1 { get; set; }
    }
}
