using System.Collections;

namespace MarkovDemo;

public class MarkovDictionary : IEnumerable<KeyValuePair<MarkovKey, List<string>>>
{
    private const string Eos = "__END_OF_SENTENCE__";

    private readonly Dictionary<MarkovKey, List<string>> _innerDictionary = new();

    private static readonly MarkovKey s_startKey = new();

    public void AddSentence(params string[] words)
    {
        var key = s_startKey;

        foreach (var word in words)
        {
            _innerDictionary.AddOrGetExisting(key).Add(word);

            key = key.Push(word);
        }

        _innerDictionary.AddOrGetExisting(key).Add(Eos);
    }

    public IReadOnlyList<string> BuildSentence()
    {
        var result = new List<string>();

        var key = s_startKey;

        while (true)
        {
            var list = _innerDictionary[key];

            var word = list[Random.Shared.Next(list.Count)];

            if (word == Eos)
            {
                break;
            }

            result.Add(word);

            key = key.Push(word);
        }

        return result;
    }

    public IEnumerator<KeyValuePair<MarkovKey, List<string>>> GetEnumerator() => _innerDictionary.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}