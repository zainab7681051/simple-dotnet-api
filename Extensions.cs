//file for extendng the difetions of a type(class) by
// adding methods to them
//NOTE extentions methods we must use static

using dotnet_core_app.Dtos;
using dotnet_core_app.Entity;

namespace dotnet_core_app
{
    public static class Extentions
    {
        public static ItemDto AsDto(this Item item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            return new ItemDto
            {
                id = item.id,
                name = item.name,
                price = item.price,
                createDate = item.createDate
            };
        }
    }
}
