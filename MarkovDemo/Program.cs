namespace MarkovDemo;

class Program
{
    static void Main(string[] args)
    {
        var markovDic = new MarkovDictionary();

        markovDic.AddSentence("今日", "の", "天気", "は", "晴れ", "です。");
        markovDic.AddSentence("明日", "の", "天気", "は", "雨", "です。");

        for (var i = 0; i < 10; i++)
        {
            Console.WriteLine(string.Join(" / ", markovDic.BuildSentence()));
        }
    }
}