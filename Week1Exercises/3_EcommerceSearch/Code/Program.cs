using System;

// Product class with searchable attributes
public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }

    public Product(int id, string name, string category)
    {
        ProductId = id;
        ProductName = name;
        Category = category;
    }
}

class Program
{
    // Linear search
    static int LinearSearch(Product[] products, int productId)
    {
        for (int i = 0; i < products.Length; i++)
            if (products[i].ProductId == productId)
                return i;
        return -1;
    }

    // Binary search (requires sorted array)
    static int BinarySearch(Product[] products, int productId)
    {
        int left = 0, right = products.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (products[mid].ProductId == productId)
                return mid;
            if (products[mid].ProductId < productId)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return -1;
    }

    static void Main(string[] args)
    {
        // Example products (unsorted for linear, sorted for binary)
        Product[] productsForLinearSearch = new Product[]
        {
            new Product(3, "Laptop", "Electronics"),
            new Product(1, "Phone", "Electronics"),
            new Product(2, "Mouse", "Electronics")
        };

        Product[] productsForBinarySearch = new Product[]
        {
            new Product(1, "Phone", "Electronics"),
            new Product(2, "Mouse", "Electronics"),
            new Product(3, "Laptop", "Electronics")
        };

        // Search for product with ID 2
        int linearResult = LinearSearch(productsForLinearSearch, 2);
        int binaryResult = BinarySearch(productsForBinarySearch, 2);

        Console.WriteLine("E-commerce Platform Search Function");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Linear Search Result (index): " + linearResult);
        Console.WriteLine("Binary Search Result (index): " + binaryResult);

        // Analysis
        Console.WriteLine("\nAnalysis:");
        Console.WriteLine("- Linear Search: O(n) time complexity (worst, average, best case).");
        Console.WriteLine("- Binary Search: O(log n) time complexity (worst, average), but requires a sorted array.");
        Console.WriteLine("- For large catalogs, binary search is much faster than linear search.");
        Console.WriteLine("- For small or unsorted data, linear search is simple and sufficient.");
    }
}
