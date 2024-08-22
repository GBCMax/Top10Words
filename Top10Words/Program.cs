internal class Program
{
  private static Dictionary<string, int> _words = [];
  private static void Main(string[] args)
  {
    using var sr = new StreamReader("Data\\Text2.txt");

    string text = sr.ReadToEnd();

    var noPunctuationText = new string(text.Where(x => !char.IsPunctuation(x)).ToArray()).Trim();

    noPunctuationText = noPunctuationText.Replace("  ", " ");

    foreach (var word in noPunctuationText.Split(' '))
    {
      if (_words.ContainsKey(word.ToLower()))
      {
        _words[word.ToLower()]++;
      }
      else
      {
        _words.Add(word.ToLower(), 1);
      }
    }

    var topWords = _words.OrderBy(w => w.Value).Reverse().Take(10);

    Console.WriteLine($"Топ 10 слов:");

    foreach (var word in topWords)
    {
      Console.WriteLine($"{word.Key} - {word.Value}");
    }
  }
}