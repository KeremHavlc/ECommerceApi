namespace Entity.Concrete
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User{ get; set; }
        public double TotalPrice { get; set; }
        public string Status { get; set; }
        public Guid? AddressId { get; set; }
        public Address Address{ get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } 
    }
}
