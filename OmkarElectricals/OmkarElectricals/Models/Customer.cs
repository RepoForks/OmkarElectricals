using SQLite.Net.Attributes;

namespace OmkarElectricals.Models
{
    [Table("Customer")]
    public class Customer
    {
        [PrimaryKey, AutoIncrement]
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public long CustomerMobileNumber { get; set; }
        public string CustomerAddress { get; set; }
    }
}
