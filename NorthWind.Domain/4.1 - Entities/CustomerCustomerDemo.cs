namespace NorthWind.Domain.Entities
{
    public class CustomerCustomerDemo
    {
        public CustomerCustomerDemo()
        {

        }

        public string CustomerId { get; set; }
        public string CustomerTypeId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual CustomerDemographic CustomerType { get; set; }
    }
}
