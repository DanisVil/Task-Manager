using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager
{
    class Report
    {
        private string text;
        private DateTime date_of_receiving_of_the_task;
        private DateTime deadline;
        private DateTime date_of_completion;
        private Employee executor;
        private float probability;
        public Report(string text, DateTime dorott, DateTime deadline, DateTime doc, Employee executor)
        {
            this.text = text;
            date_of_receiving_of_the_task = dorott;
            this.deadline = deadline;
            date_of_completion = doc;
            this.executor = executor;
            if (date_of_completion.Equals(deadline))
            {
                probability = 0.95f;
            }
            else
            {
                probability = 0.95f * (date_of_completion - date_of_receiving_of_the_task).Days
                    / (deadline - date_of_receiving_of_the_task).Days;
            }
        }
        public byte GetProbability()
        {
            return (byte)Math.Floor(probability * 100);
        }
        public DateTime Deadline
        {
            get
            {
                return deadline;
            }
        }
        public DateTime DateOfCompletion
        {
            get
            {
                return date_of_completion;
            }
        }
    }
}
