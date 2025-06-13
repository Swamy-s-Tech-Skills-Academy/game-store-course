using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Models;

public class Game
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "The name must be between 3 and 50 characters long.")]
    public required string Name { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "The genre must be between 3 and 20 characters long.")]
    public required string Genre { get; set; }

    [Range(1, 100, ErrorMessage = "The price must be between $1 and $100.")]
    public decimal Price { get; set; }

    public DateOnly ReleaseDate { get; set; }
}
