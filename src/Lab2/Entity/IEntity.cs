namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public interface IEntity<T>
{
    int Id { get; }
}

public sealed class EntityCounter<T>
{
    private EntityCounter() { }

    private static int counter = 0;

    public static int Next() => counter++;
}