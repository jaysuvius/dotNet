//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MayPsApit.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Company
    {
        public System.Guid CompanyId { get; set; }
        public Nullable<System.Guid> CompanyName { get; set; }
        public Nullable<System.Guid> CompanyType { get; set; }
        public Nullable<System.Guid> AddressId { get; set; }
        public Nullable<System.Guid> PrimaryContactId { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
