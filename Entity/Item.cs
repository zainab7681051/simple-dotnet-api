namespace simple_dotnet_api.Entity
{
    public record Item
    {
        //record types: use for immutable objects
        //that do not change thru out the prorgam
        //has expression support
        // has value-based equality support which means
        //when comparing two objects they must have the same
        //properties and not just be equal in their identity properties,
        //i.e int id is the same but string name is diffrent
        //so they are not equal
        public Guid id { get; init; }

        //Guid means id is a unique number; will not be duplicated
        //init  means we set our property value when creating instance of it.
        //and cannot access it later after initializing
        //i.e: correct==> Item item = new(){id=Guid.NewGuid()};
        //incorrect ==> Item item= new(); item.id=Guid.NewGuid();
        public string name { get; init; }
        public decimal price { get; init; }
        public DateTimeOffset createDate { get; init; }
    }
}
