namespace Itmo.ObjectOrientedProgramming.Lab4.Settings.Entities;

public interface ISetting
{
    string Key { get; }
}

public interface ISetting<T> : ISetting
{
    T GetValue();

    void Update(T value);
}