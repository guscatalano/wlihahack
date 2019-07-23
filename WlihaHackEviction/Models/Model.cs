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
}
