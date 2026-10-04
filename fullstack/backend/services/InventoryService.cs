namespace InventoryHub.Api.Models
{
    public class InventoryItemDto
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; }
    }
}
