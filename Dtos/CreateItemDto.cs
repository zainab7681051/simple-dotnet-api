namespace dotnet_core_app.Dtos
{
    public record CreateItemDto
    {
        public string name { get; init; }
        public decimal price { get; init; }
    }
}