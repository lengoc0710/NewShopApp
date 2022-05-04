﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NewShopApp.ViewModels.System.User
{
   public  class RegisterRequest
    {
        public string FirstName { get; set; }

        //[Display(Name = "Họ")]
        public string LastName { get; set; }

        //[Display(Name = "Ngày sinh")]
        //[DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        //[Display(Name = "Hòm thư")]
        public string Email { get; set; }

        //[Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}