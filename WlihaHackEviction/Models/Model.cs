using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WlihaHackEviction.Models
{
    [DataContractAttribute(Name ="TenantsInfo")]
    public class TenantInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int NumberOfPpl { get; set; }
        public int AddressId { get; set; }
    }

    public class AddressInfo
    {
        public long Id { get; set; }
        public string StreetAddress { get; set; }
        public int Unit { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public int ZipCode { get; set; }
    }

    public class EvictionInfo
    {
        public long Id { get; set; }
        public DateTime DateOfEviction { get; set; }
    }
}
