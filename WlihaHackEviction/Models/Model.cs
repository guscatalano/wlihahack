using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

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
        public double Latitude { get; set; }
        [DataMember]
        public double Longitude { get; set; }
    }

    [DataContract]
    public class EvictionInfo
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime DateOfEviction { get; set; }
        [DataMember]
        public byte[] EvictionNotice { get; set; }
        [DataMember]
        public byte[] Lease { get; set; }

        [DataMember]
        public bool Verified { get; set; }
        [DataMember]
        public string Notes { get; set; }
        [DataMember]
        public int TenantId { get; set; }

        [DataMember]
        public int AddressId { get; set; }
        [DataMember]
        public int PreparerId { get; set; }
    }

    [DataContract]
    public class PreparerInfo
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
        public string Organization { get; set; }
    }

    [DataContract]
    public class CompleteTenantEvictionInfo
    {
        [DataMember]
        public TenantInfo TenantInfo { get; set; }
        [DataMember]
        public AddressInfo AddressInfo { get; set; }
        [DataMember]
        public EvictionInfo EvictionInfo { get; set; }

        [DataMember]
        public PreparerInfo PreparerInfo { get; set; }
    }

    public class EvictionResult
    {
        public AddressInfo AddressInfo { get; set; }
        public DateTime DateOfEviction { get; set; }
        public int NumberOfPpl { get; set; }
    }

    [DataContract]
    public class PermitInfo
    {
        [DataMember]
        public string PermitNum { get; set; }
        [DataMember]
        public string PermitClass { get; set; }
        [DataMember]
        public string PermitClassMapped { get; set; }
        [DataMember]
        public string PermitTypeMapped { get; set; }
        [DataMember]
        public string PermitTypeDesc{ get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int HousingUnits{ get; set; }
        [DataMember]
        public int HousingUnitsRemoved { get; set; }
        [DataMember]
        public int HousingUnitsAdded { get; set; }
        [DataMember]
        public float EstProjectCost { get; set; }
        [DataMember]
        public DateTime AppliedDate { get; set; }
        [DataMember]
        public DateTime IssuedDate { get; set; }
        [DataMember]
        public DateTime ExpiresDate { get; set; }
        [DataMember]
        public DateTime CompletedDate { get; set; }
        [DataMember]
        public string StatusCurrent { get; set; }
        [DataMember]
        public string OriginalAddress1 { get; set; }
        [DataMember]
        public string OriginalCity { get; set; }
        [DataMember]
        public string OriginalState { get; set; }
        [DataMember]
        public int OriginalZip { get; set; }
        [DataMember]
        public string ContractorCompanyName { get; set; }
        [DataMember]
        public string Link { get; set; }
        [DataMember]
        public float Latitude { get; set; }
        [DataMember]
        public float Longitude { get; set; }
        [DataMember]
        public string Location1 { get; set; }
    }
}
