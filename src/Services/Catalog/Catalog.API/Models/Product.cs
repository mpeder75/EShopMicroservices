
// = default! bruges til at undertrykke en advarsel om at værdien kan være null
namespace Catalog.API.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string ImageFile { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        // Navigation property
        public List<string> Category { get; set; } = new();
    }
}
