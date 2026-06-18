using System;

public class Entry
{
    public string date;
    public string promptText;
    public string entryText;

    public void Display()
    {
        Console.WriteLine($"Date: {date} - Prompt: {promptText}");
        Console.WriteLine($"{entryText}\n");
    }
}