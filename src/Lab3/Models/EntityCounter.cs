namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public sealed class EntityCounter<T>
{
    private EntityCounter() { }

    private static int counter = 0;

    public static int Next() => counter++;
}