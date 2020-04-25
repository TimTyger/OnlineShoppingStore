using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Models
{
    public class UserModel
    {
        
        public int UserId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage ="Enter valid mail format")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Passwrod is required")]
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public Nullable<System.DateTime> DateDeleted { get; set; }

       
    }

    public class RoleModel
    {
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string RoleName { get; set; }
    }

    public class UserRoleModel
    {
        public int UserRoleId { get; set; }

        [Required(ErrorMessage = "User is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public int RoleId { get; set; }
    }
}