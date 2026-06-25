public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        
        // Split the text into separate words and store them
        _words = new List<Word>();
        string[] wordArray = text.Split(' ');
        
        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        int wordsToHideCount = Math.Min(numberToHide, visibleWords.Count);
        
        for (int i = 0; i < wordsToHideCount; i++)
        {
            int randomIndex = _random.Next(0, visibleWords.Count);
            visibleWords[randomIndex].Hide();
            visibleWords.RemoveAt(randomIndex); 
        }
    }

    public string GetDisplayText()
    {
        string referenceDisplay = _reference.GetDisplayText();
        string scriptureDisplay = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        
        return $"{referenceDisplay} {scriptureDisplay}";
    }

    public bool IsCompletelyHidden()
    {
        // Returns true if all words are hidden
        return _words.All(w => w.IsHidden());
    }
}