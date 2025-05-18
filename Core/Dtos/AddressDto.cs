namespace Core.Dtos
{
    public class AddressDto
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Destrict { get; set; }
        public string Street { get; set; }
        public int PostalCode { get; set; }
    }
}
