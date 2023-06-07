/*
DTO(DATA TRANSFER OBJECT)
contract between client and service to prevent entity
classes that contain the data the client is requesting
from being exposed to the outside world. in
other words, client has to talk to the dto service to get
the database data from entity which maps out the data
instead of directly getting everything directly from
a service that returns the entity.
useful: https://www.telerik.com/blogs/dotnet-basics-dto-data-transfer-object

NOTE:dto might not be that much needed here
because we are returing id, name, price, etc to the client
since we need all this. perhaps we can leave out the date of creation when returning the data
by deleteing it in the dto class properties so it wont be included with returend data.
nevertheless, it is an idea that will be useful in the future imo.
*/
namespace simple_dotnet_api.Dtos
{
    public record ItemDto
    {
        public Guid id { get; init; }
        public string name { get; init; }
        public decimal price { get; init; }
        public DateTimeOffset createDate { get; init; }
    }
}
