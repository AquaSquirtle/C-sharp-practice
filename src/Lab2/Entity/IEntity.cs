namespace Itmo.ObjectOrientedProgramming.Lab2.Entity;

public interface IEntity<T>
{
    int Id { get; }
}

public static class EntityCounter<T>
{
    private static int counter = 0;

    public static int Next() => counter++;
}