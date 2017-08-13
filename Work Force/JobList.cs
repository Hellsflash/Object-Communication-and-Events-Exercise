using System;
using System.Collections.Generic;

public class JobList : List<Job>
{
    public void JobDone(object sender, JobEventArgs e)
    {
        this.Remove(e.Job);
    }
}