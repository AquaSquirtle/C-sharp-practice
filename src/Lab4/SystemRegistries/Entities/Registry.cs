namespace Itmo.ObjectOrientedProgramming.Lab4.SystemRegistries.Entities;

public class Registry<T>
{
    private readonly SortedDictionary<string, T> _items = new();

    private Registry(SortedDictionary<string, T> items)
    {
        _items = items;
    }

    public void Register(string key, T item)
    {
        if (_items.ContainsKey(key))
        {
            throw new InvalidOperationException($"Object {key} already registered.");
        }

        _items[key] = item;
    }

    public bool Contains(string key)
    {
        return _items.ContainsKey(key);
    }

    public T Get(string key)
    {
        if (!_items.TryGetValue(key, out T? item))
        {
            throw new KeyNotFoundException($"key: {key} not found.");
        }

        return item;
    }

    public ICollection<string> GetAllKeys()
    {
        return _items.Keys;
    }

    public class RegistryBuilder
    {
        private readonly SortedDictionary<string, T> _items = new();

        public RegistryBuilder Add(string key, T item)
        {
            _items.Add(key, item);
            return this;
        }

        public Registry<T> Build()
        {
            return new Registry<T>(_items);
        }
    }
}
