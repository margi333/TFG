using System.Runtime.InteropServices;

public static class MyLibrary
{
    [UnmanagedCallersOnly(EntryPoint = "suma")]
    public static void suma(int a, int b)
    {
        Console.WriteLine($"La suma val {a + b}");
    }
}
