using System;

class Program
{
    // Recursive function to forecast future value based on growth rate
    // This function calculates the future value after a number of periods
    static double ForecastValue(double currentValue, double growthRate, int periods)
    {
        if (periods == 0)
            return currentValue; // Base case: no more periods to forecast
        double nextValue = currentValue * (1 + growthRate);
        return ForecastValue(nextValue, growthRate, periods - 1); // Recursive case
    }

    static void Main(string[] args)
    {
        double initialValue = 1000.0;
        double growthRate = 0.05; // 5% growth per period
        int periods = 5;

        double futureValue = ForecastValue(initialValue, growthRate, periods);

        Console.WriteLine("Financial Forecasting Recursive Example");
        Console.WriteLine("---------------------------------------");
        Console.WriteLine($"Initial Value: {initialValue}");
        Console.WriteLine($"Growth Rate per Period: {growthRate * 100}%");
        Console.WriteLine($"Number of Periods: {periods}");
        Console.WriteLine($"Forecasted Future Value: {futureValue:F2}");
        Console.WriteLine();
        // Analysis of the recursive function
        Console.WriteLine("Analysis:");
        Console.WriteLine("- **Recursion**: The function calls itself with a smaller subproblem until it reaches the base case (periods == 0).");
        Console.WriteLine("- **Time Complexity**: O(n) — linear time, where n is the number of periods. Each period adds one recursive call.");
        Console.WriteLine("- **Optimization**: To avoid excessive stack usage for large n, consider using an iterative loop instead of recursion.");
        Console.WriteLine("- **Tail Recursion**: This function is tail-recursive, but C# does not optimize tail recursion by default. For large n, use iteration for efficiency.");
    }
}
