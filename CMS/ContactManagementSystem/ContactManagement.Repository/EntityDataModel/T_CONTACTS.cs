//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ContactManagement.Repository.EntityDataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_CONTACTS
    {
        public int contact_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public Nullable<long> phone { get; set; }
        public string status { get; set; }
    }
}
