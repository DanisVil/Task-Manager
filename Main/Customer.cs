using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager
{
    class Customer: Person
    {
        public Project CreateProject(string description, DateTime deadline, TeamLead teamlead)
        {
            Project project = new Project(description, deadline, teamlead, this);
            teamlead.AddProject(project);
            return project;
        }
    }
}
