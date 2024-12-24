namespace MockDataGenerator;

public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var mockGenerator = new MockDataGeneratr();
        var result = mockGenerator.GenerateMockData();
        Console.WriteLine(mockGenerator.GenerateMockDataToJsonString());
    }
}