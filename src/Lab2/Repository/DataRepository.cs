using Itmo.ObjectOrientedProgramming.Lab2.Entity;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public class DataRepository<T> where T : IEntity<T>
{
    public ICollection<T> Entities { get; } = new List<T>();

    public void Add(T entity)
    {
        Entities.Add(entity);
    }

    public T? FindById(int id)
    {
        return Entities.FirstOrDefault(e => e.Id == id);
    }
}