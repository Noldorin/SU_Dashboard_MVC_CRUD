using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Dashboard_FrontEnd_Prototype.Models
{
    public class UserModel
    {

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Must have a Name")]
        public string name;

        [Display(Name = "Role")]
        [Required(ErrorMessage = "Must have a Role")]
        public Roles role;

        public enum Roles { Engineer, Manager };

    }
}