namespace simple_dotnet_api.Dtos
{
    public record CreateItemDto
    {
        public string name { get; init; }
        public decimal price { get; init; }
    }
}