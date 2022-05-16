using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewShopApp.ViewModels.System.User
{
    public class UserVm
    {
        public Guid Id { get; set; }

        [Display(Name = "First Name")]
        
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Display(Name = "Email")]

        public string Email { get; set; }
        [Display(Name = "Date Of Birth")]
        public DateTime Dob { get; set; }

        public IList<string> Roles { get; set; }
    }
}
