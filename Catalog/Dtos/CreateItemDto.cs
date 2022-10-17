using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record CreateItemDto
    {
        [Required]
        [MaxLength(100)]
        [MinLength(4)]
        public string Name { get; init; }
        [Required]
        [Range(1,1000)]
        public decimal Price { get; init; }
    }
}
