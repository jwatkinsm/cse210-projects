using System;

public class Resume
{
    // Member variables
    public string _name;
    
    // Initialize the list of jobs immediately when declared
    public List<Job> _jobs = new List<Job>();

    // Displays the entire resume
    public void DisplayResumeDetails()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        
        // Iterate through each job in the list
        foreach (Job job in _jobs)
        {
            job.DisplayJobDetails();
        }
    }
}