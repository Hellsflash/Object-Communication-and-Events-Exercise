using System;

public class Job
{

    public event StartUp.JobDoneEventHandler JobDone;

    public Job(string name, int workHoursNeeded, BaseEmploee emploee)
    {
        this.Name = name;
        this.WorkHoursNeeded = workHoursNeeded;
        this.Emploee = emploee;
        this.IsDone = false;
    }

    public string Name { get; private set; }
    public int WorkHoursNeeded { get; private set; }
    public BaseEmploee Emploee { get; private set; }
    public bool IsDone { get; private set; }

    public void Update()
    {
        this.WorkHoursNeeded -= Emploee.WorkHoursPerWeek;

        if (this.WorkHoursNeeded <= 0 && this.IsDone == false)
        {
            if (JobDone != null)
            {
                JobDone(this, new JobEventArgs(this));
            }
        }
    }

    public void OnJobDone(object sender, EventArgs e)
    {

        Console.WriteLine($"Job {this.Name} done!");
        this.IsDone = true;
    }

    public override string ToString()
    {
        return $"Job: {this.Name} Hours Remaining: {this.WorkHoursNeeded}";
    }
}