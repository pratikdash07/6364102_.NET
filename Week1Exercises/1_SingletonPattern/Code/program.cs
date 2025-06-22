class Program
{
    static void Main(string[] args)
    {
        Logger logger1 = Logger.Instance;
        Logger logger2 = Logger.Instance;

        Console.WriteLine($"logger1 == logger2: {logger1 == logger2}");

        logger1.Log("First log entry");
        logger2.Log("Second log entry");

        Parallel.Invoke(
            () => Logger.Instance.Log("Thread 1 log"),
            () => Logger.Instance.Log("Thread 2 log")
        );
    }
}
