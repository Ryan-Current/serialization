namespace serialization;
/// <summary>
/// This class will be used to create objects that will be serialized. This is 
/// supposed to represent a typical class. 
/// </summary>
public class SerialzableObject
{
    public int IntegerAttribute { get; set; } = 0; 
    public string StringAttribute { get; set; } = "This is an example string that must be serialized"; 
    public bool BoolAttribute { get; set; } = false; 
}
