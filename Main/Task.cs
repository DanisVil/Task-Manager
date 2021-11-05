using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager
{
    class Task
    {
        public enum Status { Assigned = 0, UnderDevelopment = 1, OnCheck = 2, Accomplished = 3 };
        private Status status;
        private string description;
        private DateTime date_of_receiving;
        private DateTime deadline;
        private TeamLead initiator;
        private Employee executor;
        public Task(string description, DateTime deadline, TeamLead initiator)
        {
            this.description = description;
            date_of_receiving = DateTime.Today;
            this.deadline = deadline;
            this.initiator = initiator;
            status = Status.Assigned;
        }
        public void AssignTask(Employee employee)
        {
            status = Status.UnderDevelopment;
            executor = employee;
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
        public DateTime DateOfReceiving
        {
            get
            {
                return date_of_receiving;
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
    }
}
