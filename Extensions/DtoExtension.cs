//file for extendng the difetions of a type(class) by
// adding methods to them
//NOTE extentions methods must be static
//https://www.tutorialsteacher.com/csharp/csharp-extension-method

using dotnet_core_app.Dtos;
using dotnet_core_app.Entity;

namespace dotnet_core_app.Extensions
{
    public static class DtoExtention
    {
        public static ItemDto AsDto(this Item item)
        //'this' means that the "Item item" has 
        //an AsDto method that returns ItemDto instance
        {
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
