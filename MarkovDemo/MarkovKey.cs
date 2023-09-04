namespace MarkovDemo;

public readonly struct MarkovKey : IEquatable<MarkovKey>
{
    public MarkovKey()
    {
        _keys = s_emptyKeys;
    }

    private MarkovKey(params string[] keys)
    {
        _keys = keys;
    }

    private const int ReferenceKeySize = 2;
    private const string DefaultKeySeparator = ":";

    private readonly IReadOnlyList<string> _keys;

    private static readonly int s_globalRandomSeed = Random.Shared.Next(0, int.MaxValue);
    private static readonly IReadOnlyList<string> s_emptyKeys = Enumerable.Repeat("", ReferenceKeySize).ToArray();

    public MarkovKey Push(string key)
    {
        var newKeys = new string[ReferenceKeySize];

        newKeys[0] = key;

        for (var i = 0; i < ReferenceKeySize - 1; i++)
        {
            newKeys[i + 1] = _keys[i];
        }

        return new MarkovKey(newKeys);
    }

    public override int GetHashCode() => _keys.Aggregate(s_globalRandomSeed, (current, key) => current ^ key.GetHashCode());

    public override string ToString() => string.Join(DefaultKeySeparator, _keys);

    public override bool Equals(object? obj) => Equals((MarkovKey)obj);

    public bool Equals(MarkovKey other) => _keys.SequenceEqual(other._keys);

    public static bool operator ==(MarkovKey left, MarkovKey right) => left.Equals(right);

    public static bool operator !=(MarkovKey left, MarkovKey right) => !(left == right);
}