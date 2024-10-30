namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public class DataRepository
{
    private readonly Dictionary<Guid, List<object>> _repository = new Dictionary<Guid, List<object>>();

    private DataRepository() { }

    public static DataRepository Instance { get; } = new DataRepository();

    public void AddEntity<T>(T entity) where T : class
    {
        if (!_repository.ContainsKey(typeof(T).GUID))
        {
            _repository[typeof(T).GUID] = new List<object>();
        }

        _repository[typeof(T).GUID].Add(entity);
    }

    public ICollection<T> GetEntities<T>() where T : class
    {
        if (_repository.ContainsKey(typeof(T).GUID))
        {
            return _repository[typeof(T).GUID].Cast<T>().ToList();
        }

        return new List<T>();
    }
}