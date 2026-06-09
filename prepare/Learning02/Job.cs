using System;

public class Job
{
    // Member variables 
    public string _company;
    public string _jobTitle;
    public string _startYear;
    public string _endYear;

    // Displays the job information
    public void DisplayJobDetails()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}