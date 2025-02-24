using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Invoice : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Number { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<InvoiceDetail> InvoiceDetails { get; set; } = new();

        public decimal Total
        {
            get
            {
                decimal total = 0;
                foreach (var item in InvoiceDetails)
                {
                    total += item.Quantity * item.Price;
                }
                return total;
            }
        }
    }
}
