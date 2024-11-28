namespace Itmo.ObjectOrientedProgramming.Lab4.Settings.Entities;

public class SettingsManager
{
    private static readonly Lazy<SettingsManager> _instance = new(() => new SettingsManager());

    private readonly SortedDictionary<string, ISetting> _settings = new();

    private SettingsManager() { }

    public static SettingsManager Instance => _instance.Value;

    public void RegisterSetting(ISetting setting)
    {
        if (_settings.ContainsKey(setting.Key))
        {
            throw new InvalidOperationException($"Setting with key '{setting.Key}' is already registered.");
        }

        _settings[setting.Key] = setting;
    }

    public TSetting GetSetting<TSetting>(string key) where TSetting : class, ISetting
    {
        if (!_settings.TryGetValue(key, out ISetting? setting))
        {
            throw new KeyNotFoundException($"Setting with key '{key}' not found.");
        }

        return setting as TSetting
               ?? throw new InvalidCastException($"Setting with key '{key}' is not of type {typeof(TSetting)}.");
    }

    public void SetSettingValue<T>(string key, T value)
    {
        ISetting<T> setting = GetSetting<ISetting<T>>(key);
        setting.Update(value);
    }

    public T GetSettingValue<T>(string key)
    {
        ISetting<T> setting = GetSetting<ISetting<T>>(key);
        return setting.GetValue();
    }
}