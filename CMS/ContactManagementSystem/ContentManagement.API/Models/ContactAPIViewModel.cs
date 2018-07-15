using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContentManagement.API.Models
{
    public class ContactAPIViewModel
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Nullable<long> Phone { get; set; }
        public string Status { get; set; }
    }
}