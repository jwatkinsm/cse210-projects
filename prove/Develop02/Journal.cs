using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        entries.Add(newEntry);
    }
    public void DisplayAll()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("The journal is currently empty.");
            return;
        }
        foreach (Entry entry in entries)
        {
            entry.Display();
        }
    }
    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in entries)
            {
                outputFile.WriteLine($"{entry.date}|{entry.promptText}|{entry.entryText}");

            }

        }
        Console.WriteLine("Journal saved succesfully!");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.");
            return;
        }
        entries.Clear();
        string[] lines = File.ReadAllLines(file);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                Entry newEntry = new Entry();
                newEntry.date = parts[0];
                newEntry.promptText = parts[1];
                newEntry.entryText = parts[2];
                entries.Add(newEntry);
            }
        }
        Console.WriteLine("Journal Loaded succesfully! ");
    }
}