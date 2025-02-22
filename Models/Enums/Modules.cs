using System.ComponentModel;

namespace Models.Enums
{
    public enum Modules
    {
        [Description("Roles")]
        Roles,

        [Description("Users")]
        Users,

        [Description("Permissions")]
        Permissions,

        [Description("Customers")]
        Customers,

        [Description("Brands")]
        Brands,

        [Description("Vehicles")]
        Vehicles,

        [Description("Invoices")]
        Invoices,

        [Description("Reports")]
        Reports
    }
}