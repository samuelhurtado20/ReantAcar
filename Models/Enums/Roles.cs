using System.ComponentModel.DataAnnotations;

namespace Models.Enums
{
    public enum Roles
    {
        [Display(Name = "System Administrator")]
        SystemAdmin = 1,

        [Display(Name = "Administrator")]
        Admin = 2,

        [Display(Name = "Seller")]
        Seller = 3,

        [Display(Name = "Customer")]
        Customer = 4,
    }
}