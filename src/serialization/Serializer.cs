namespace serialization; 
/// <summary>
/// The functions and data in this class can be used to test serialization speeds. 
/// </summary>
public class Serializer
{
    private const int LISTSIZE = 100000; 
    private List<SerializableObject> serializeList { get; set; } = new(); 


    public Serializer()
    {
        // init the serializeList to dummy data
        for(int i = 0; i < LISTSIZE; i++)
            serializeList.Add(new SerializableObject()); 
    }


    public void TestSystemTextJson()
    {
        var watch = Stopwatch.StartNew(); 
        string json = System.Text.Json.JsonSerializer.Serialize(serializeList); 
        watch.Stop(); 
        Console.WriteLine($"SystemTextSerializer serialization took: {watch.ElapsedMilliseconds/1000.0} seconds"); 

        watch = Stopwatch.StartNew();
        List<SerializableObject> deserialized = System.Text.Json.JsonSerializer.Deserialize<List<SerializableObject>>(json) ?? new(); 
        watch.Stop();
        Console.WriteLine($"SystemTextSerializer deserialization took: {watch.ElapsedMilliseconds/1000.0} seconds"); 
    }


    public void TestNewtonsoft()
    {
        var watch = Stopwatch.StartNew(); 
        string json = JsonConvert.SerializeObject(serializeList); 
        watch.Stop(); 
        Console.WriteLine($"NewtonsoftSerializer serialization took: {watch.ElapsedMilliseconds/1000.0} seconds"); 

        watch = Stopwatch.StartNew();
        List<SerializableObject> deserialized = JsonConvert.DeserializeObject<List<SerializableObject>>(json) ?? new(); 
        watch.Stop();
        Console.WriteLine($"NewtonsoftSerializer deserialization took: {watch.ElapsedMilliseconds/1000.0} seconds"); 
    }


    public void TestMemoryPack()
    {
        var watch = Stopwatch.StartNew(); 
        byte[] packed = MemoryPackSerializer.Serialize(serializeList); 
        watch.Stop(); 
        Console.WriteLine($"MemPackSerializer serialization took: {watch.ElapsedMilliseconds/1000.0} seconds"); 

        watch = Stopwatch.StartNew();
        List<SerializableObject> deserialized = MemoryPackSerializer.Deserialize<List<SerializableObject>>(packed) ?? new(); 
        watch.Stop();
        Console.WriteLine($"MemPackSerializer deserialization took: {watch.ElapsedMilliseconds/1000.0} seconds");
    }

    
    public void TestMessagePack()
    { 
        var watch = Stopwatch.StartNew(); 
        byte[] packed = MessagePackSerializer.Serialize(serializeList); 
        watch.Stop(); 
        Console.WriteLine($"MessagePackSerializer serialization took: {watch.ElapsedMilliseconds/1000.0} seconds"); 

        watch = Stopwatch.StartNew();
        List<SerializableObject> deserialized = MessagePackSerializer.Deserialize<List<SerializableObject>>(packed) ?? new(); 
        watch.Stop();
        Console.WriteLine($"MessagePackSerializer deserialization took: {watch.ElapsedMilliseconds/1000.0} seconds");
    }
}

public class Model 
{
    public SerializableObject[] List;  
}