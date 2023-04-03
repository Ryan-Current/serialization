using serialization; 

Serializer serializer = new(); 
bool run = true; 
while(run)
{
    Console.Write("(s)system, (n)newtonsoft, (mm)mempack, or (ms)messagepack >> "); 
    var input = Console.In.ReadLine(); 

    switch(input)
    {
        case "s":
            Console.WriteLine(); 
            serializer.TestSystemTextJson(); 
            Console.WriteLine(); 
            break; 
        case "n":
            Console.WriteLine(); 
            serializer.TestNewtonsoft(); 
            Console.WriteLine(); 
            break; 
        case "mm":
            Console.WriteLine(); 
            serializer.TestMemoryPack(); 
            Console.WriteLine(); 
            break; 
        case "ms":
            Console.WriteLine(); 
            serializer.TestMessagePack(); 
            Console.WriteLine(); 
            break; 
        case "stop":
            run = false; 
            break; 
        default:
            Console.WriteLine(); 
            Console.WriteLine("Invalid input, try again."); 
            Console.WriteLine(); 
            break; 
    }
}
