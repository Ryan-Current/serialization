namespace serialization;
/// <summary>
/// This class will be used to create objects that will be serialized. This is 
/// supposed to represent a typical class. 
/// </summary>
[MemoryPackable]
[MessagePackObject]
public partial class SerializableObject
{
    [Key(0)]
    public int IntegerAttribute { get; set; } = 0; 
    [Key(1)]
    public string StringAttribute { get; set; } = "This is an example string that must be serialized"; 
    [Key(2)]
    public bool BoolAttribute { get; set; } = false; 
}
