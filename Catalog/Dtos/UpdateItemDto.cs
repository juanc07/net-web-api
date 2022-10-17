﻿using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record UpdateItemDto
    {
        [Required]
        [MaxLength(500)]
        [MinLength(10)]
        public string Name { get; init; }
        [Required]
        [Range(1,1000)]
        public decimal Price { get; init; }
    }
}
