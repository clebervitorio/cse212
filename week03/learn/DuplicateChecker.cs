public class DuplicateChecker
{

    public static void Run()
    {
        var data = new string[]
        {
            "apple", "banana", "apple", "orange", "banana", "kiwi", "kiwi", "kiwi"
        };

        Console.WriteLine($"Number of items in the collection: {data.Length}");
        Console.WriteLine($"Number of duplicates: {CountDuplicates(data)}");
    }

    private static int CountDuplicates(string[] data)
    {
        var unique = new HashSet<string>();
        var duplicates = 0;
        foreach (var item in data)
        {
            if (unique.Contains(item))
            {
                duplicates++;
            }
            else
            {
                unique.Add(item);
            }
        }
        return duplicates;
    }
}