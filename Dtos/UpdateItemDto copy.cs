using System.ComponentModel.DataAnnotations;

namespace simple_dotnet_api.Dtos
{
    public record UpdateItemDto
    {
        [Required]//data annotations for required fields, name and price cannot be null 
        public string name { get; init; }
        [Required]
        [Range(1, 1000)]//range of acceteped number values
        public decimal price { get; init; }
    }
}