public class ScriptureLibrary
{
    private List<Scripture> _scriptures;

    public ScriptureLibrary()
    {
        _scriptures = new List<Scripture>();
    }

    public void AddScripture(Scripture scripture)
    {
        _scriptures.Add(scripture);
    }

    public Scripture GetRandomScripture()
    {
        if (_scriptures.Count == 0)
        {
            return null;
        }

        Random random = new Random();
        int randomIndex = random.Next(0, _scriptures.Count);
        return _scriptures[randomIndex];
    }

    public void LoadScripturesFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"Warning: The file '{filename}' was not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] parts = line.Split('|');

            if (parts.Length == 5)
            {
                string book = parts[0];
                int chapter = int.Parse(parts[1]);
                int startVerse = int.Parse(parts[2]);
                int endVerse = int.Parse(parts[3]);
                string text = parts[4];

                Reference reference = new Reference(book, chapter, startVerse, endVerse);
                Scripture scripture = new Scripture(reference, text);
                
                _scriptures.Add(scripture);
            }
        }
    }
}