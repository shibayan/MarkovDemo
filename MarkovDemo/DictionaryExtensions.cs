namespace MarkovDemo;

public static class DictionaryExtensions
{
    public static TValue AddOrGetExisting<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key) where TValue : new() where TKey : notnull
    {
        if (!dictionary.TryGetValue(key, out var value))
        {
            value = new TValue();

            dictionary.Add(key, value);
        }

        return value;
    }
}