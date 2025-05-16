namespace Core.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock{ get; set; }
        public string Image { get; set; }
        public Guid CategoryId { get; set; }
    }
}
