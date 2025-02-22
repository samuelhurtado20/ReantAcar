using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Enums;

/// <summary>
/// DEFINE SYSTEM PermissionS, IF YOU WANT TO ADD A NEW ONE JUST DO IT AT THE END OF THE LIST
/// </summary>
public enum Permissions
{
    // role
    [Display(Name = "Create Role")] Create_Role = 1,

    [Display(Name = "Read Role")] Read_Role,

    [Display(Name = "Update Role")] Update_Role,

    [Display(Name = "Delete Role")] Delete_Role,

    // user
    [Display(Name = "Create User")] Create_User,

    [Display(Name = "Read User")] Read_User,

    [Display(Name = "Update User")] Update_User,

    [Display(Name = "Delete User")] Delete_User,

    // Permission
    [Display(Name = "Create Permission")] Create_Permission,

    [Display(Name = "Read Permission")] Read_Permission,

    [Display(Name = "Update Permission")] Update_Permission,

    [Display(Name = "Delete Permission")] Delete_Permission,

    // Brand
    [Display(Name = "Create Brand")] Create_Brand,

    [Display(Name = "Read Brand")] Read_Brand,

    [Display(Name = "Update Brand")] Update_Brand,

    [Display(Name = "Read Brand")] Delete_Brand,

    // Vehicle
    [Display(Name = "Create Vehicle")] Create_Vehicle,

    [Display(Name = "Read Vehicle")] Read_Vehicle,

    [Display(Name = "Update Vehicle")] Update_Vehicle,

    [Display(Name = "Delete Vehicle")] Delete_Vehicle,

    // Invoice
    [Display(Name = "Create Invoice")] Create_Invoice,

    [Display(Name = "Read Invoice")] Read_Invoice,

    [Display(Name = "Update Invoice")] Update_Invoice,

    [Display(Name = "Delete Invoice")] Delete_Invoice,

    // Report
    [Display(Name = "Create Report")] Create_Report,

    [Display(Name = "Read Report")] Read_Report,

    [Display(Name = "Update Report")] Update_Report,

    [Display(Name = "Delete Report")] Delete_Report,

    // Customer
    [Display(Name = "Create Customer")] Create_Customer,

    [Display(Name = "Read Customer")] Read_Customer,

    [Display(Name = "Update Customer")] Update_Customer,

    [Display(Name = "Delete Customer")] Delete_Customer,
}