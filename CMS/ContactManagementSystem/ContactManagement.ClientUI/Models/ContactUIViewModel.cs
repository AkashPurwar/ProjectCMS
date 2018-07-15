using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactManagement.ClientUI.Models
{
    public class ContactUIViewModel
    {
        public int ContactId { get; set; }
        [Required(ErrorMessage="Nobody sounds good without their first name.")]
        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Enter only alphabets")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [RegularExpression("([a-zA-Z]+)", ErrorMessage = "Enter only alphabets")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is mandatory for your uniqueness.")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Contact No. needed,We will glad to call you.")]
        [Range (1111111111,999999999999,ErrorMessage ="Our Country does not support contact no below 10 or above 12(if included country code) till now.")]
        [DisplayName("Contact No.")]
        public Nullable<long> Phone { get; set; }

        //[Required(ErrorMessage = "Everybody looks for status so we!")]
        [DisplayName("Status")]
        public string Status { get; set; }
    }
}