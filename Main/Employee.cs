using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager
{
    class Employee: Person
    {
        private List<Task> tasklist = new List<Task>();
        public bool DoSomethingWithTask(Task task)
        {
            byte rand_value = (byte)rand.Next(5);
            if (rand_value < 4)
            {
                task.AssignTask(this);
                tasklist.Add(task);
                return true;
            }
            return false;
        }
        public bool DoSomethingWithTask(Task task, Employee reserve_employee)
        {
            byte rand_value = (byte)rand.Next(10);
            if (rand_value < 8)
            {
                task.AssignTask(this);
                tasklist.Add(task);
                return true;
            }
            else if (rand_value.Equals(8))
            {
                return reserve_employee.DoSomethingWithTask(task);
            }
            return false;
        }
        public Report SendReport(Task task)
        {
            if (tasklist.Contains(task))
            {
                task.PropertyStatus = Task.Status.OnCheck;
                return new Report(task.Description + " - сделано", task.DateOfReceiving, task.Deadline, DateTime.Today.AddDays(15), this);
            }
            return null;
        }
        public void TryHandOverTheTask(TeamLead teamlead)
        {
            if (!tasklist.Count.Equals(0))
            {
                TryHandOverTheTask(tasklist[0], teamlead);
            }
        }
        public void TryHandOverTheTask(Task task, TeamLead teamlead)
        {
            if (tasklist.Contains(task) && task.PropertyStatus.Equals(Task.Status.UnderDevelopment))
            {
                Report report = SendReport(task);
                if (teamlead.CheckIfReportCorrect(report))
                {
                    task.PropertyStatus = Task.Status.Accomplished;
                    tasklist.Remove(task);
                }
                else if (report.Deadline.Equals(report.DateOfCompletion))
                {
                    task.PropertyStatus = Task.Status.UnderDevelopment;
                    teamlead.ExtendDeadLine(task);
                }
                else
                {
                    task.PropertyStatus = Task.Status.UnderDevelopment;
                }
            }
        }
        public byte GetTaskCount()
        {
            return (byte)tasklist.Count;
        }
        public static int CompareWorkload(Employee x, Employee y)
        {
            return x.GetTaskCount().CompareTo(y.GetTaskCount());
        }
    }
}
