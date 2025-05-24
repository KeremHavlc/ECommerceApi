namespace Entity.Concrete
{
   public class Product : BaseEntity
   {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock{ get; set; }
        public string Image{ get; set; }
        public Guid CategoryId{ get; set; }
        public Category Category { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
