using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager
{
    class Project
    {
        public enum Status { Project = 0, Execution = 1, Closed = 2 };
        private Status status;
        private string description;
        private DateTime deadline;
        private TeamLead teamlead;
        private Customer customer;
        private List<Task> tasks = new List<Task>();
        public Project(string description, DateTime deadline, TeamLead teamlead, Customer customer)
        {
            this.description = description;
            this.deadline = deadline;
            this.teamlead = teamlead;
            this.customer = customer;
        }
        public DateTime Deadline
        {
            get
            {
                return deadline;
            }
            set
            {
                deadline = value;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        public void AddTask(Task task)
        {
            tasks.Add(task);
        }
        public Status PropertyStatus
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }
        public List<Task> GetTasks()
        {
            return tasks;
        }
        public void ClearTasks()
        {
            tasks.Clear();
        }
        public void RemoveTask(Task task)
        {
            tasks.Remove(task);
        }
    }
}
