using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            TeamLead teamlead = new TeamLead();
            for (int i = 0; i < 10; i++)
            {
                teamlead.AddTeamMember(new Employee());
            }

            Customer customer = new Customer();
            string description = "Написать сайт, который будет хранить такие-то данные," +
                " пользователь может запросить что-то, и с помощью нейросети/по каким-то алгоритмам пользователь получает что-то";
            Project project = customer.CreateProject(description, new DateTime(2022, 1, 30), teamlead);

            teamlead.CreateAndAssignTasks();
            foreach (Employee employee in teamlead.Team)
            {
                employee.TryHandOverTheTask(teamlead);
            }
            teamlead.SynchronizeProject();

            Console.ReadKey();
        }
    }
}
