using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Task_Manager
{
    class TeamLead: Person
    {
        private List<Project> projects = new List<Project>();
        private Dictionary<string, string> tasks_description = new Dictionary<string, string>()
        {
            { "пользовател", "сделать GUI" },
            { "данные", "организовать работу с БД" },
            { "алгоритм", "реализовать (...) алгоритм" },
            { "сайт", "создать сайт" },
            { "нейросет", "машинное обучение или че-то такое" }
        };
        private List<Employee> team = new List<Employee>();
        public void AddProject(Project project)
        {
            projects.Add(project);
        }
        public void AddTeamMember(Employee employee)
        {
            team.Add(employee);
        }
        public void RemoveTeamMember(Employee employee)
        {
            team.Remove(employee);
        }
        public void CreateTasks()
        {
            CreateTasks(projects[0]);
        }
        public void CreateTasks(Project project)
        {
            if (projects.Contains(project) && (project.Deadline - DateTime.Today).Days > 30 && 
                project.PropertyStatus.Equals(Project.Status.Project))
            {
                var keywords = tasks_description.Keys;
                foreach (string keyword in keywords)
                {
                    if (project.Description.Contains(keyword))
                    {
                        project.AddTask(new Task(tasks_description[keyword], DateTime.Today.AddDays
                            (rand.Next(15, 17)), this));
                    }
                }
            }
            else
            {
                Console.WriteLine("У тимлида на данный момент нет проекта, либо у проекта слишком строгий дедлайн," +
                    " либо у проекта неподходящий статус");
            }
        }
        public void AssignTasks()
        {
            AssignTasks(projects[0]);
        }
        public void AssignTasks(Project project)
        {
            if (projects.Contains(project) && !project.GetTasks().Count.Equals(0) && 
                project.PropertyStatus.Equals(Project.Status.Project))
            {
                team.Sort(Employee.CompareWorkload);
                if (team.Count.Equals(1))
                {
                    Task[] temp = new Task[project.GetTasks().Count];
                    project.GetTasks().CopyTo(temp);
                    foreach (Task task in temp)
                    {
                        team[0].DoSomethingWithTask(task);
                        if (!task.PropertyStatus.Equals(Task.Status.UnderDevelopment))
                        {
                            project.RemoveTask(task);
                        }
                    }
                    project.PropertyStatus = Project.Status.Execution;
                }
                else if (team.Count > 1)
                {
                    List<Task> temp = new List<Task>(project.GetTasks());
                    while (!temp.Count.Equals(0))
                    {
                        int flag = temp.Count;
                        for (int i = 0; i < team.Count - 1; i += 2)
                        {
                            if (team[i].DoSomethingWithTask(temp[0], team[i + 1]))
                            {
                                temp.RemoveAt(0);
                                team.Sort(Employee.CompareWorkload);
                                break;
                            }
                        }
                        if (flag.Equals(temp.Count))
                        {
                            project.RemoveTask(temp[0]);
                            temp.RemoveAt(0);
                        }
                    }
                    project.PropertyStatus = Project.Status.Execution;
                }
                else
                {
                    Console.WriteLine("В команде нет сотрудников");
                }
            }
            else
            {
                Console.WriteLine("Задачи не составлены");
            }
        }
        public void CreateAndAssignTasks()
        {
            CreateTasks(projects[0]);
            AssignTasks(projects[0]);
        }
        public void CreateAndAssignTasks(Project project)
        {
            CreateTasks(project);
            AssignTasks(project);
        }
        public bool CheckIfReportCorrect(Report report)
        {
            byte rand_value = (byte)rand.Next(100);
            if (rand_value < report.GetProbability())
            {
                return true;
            }
            return false;
        }
        public void ExtendDeadLine(Task task)
        {
            task.Deadline += new TimeSpan(rand.Next(7, 14), 0, 0, 0);
        }
        public List<Employee> Team
        {
            get
            {
                return team;
            }
        }
        public void SynchronizeProject()
        {
            SynchronizeProject(projects[0]);
        }
        public void SynchronizeProject(Project project)
        {
            project.PropertyStatus = (project.GetTasks().All(x => x.PropertyStatus.Equals(Task.Status.Accomplished)) &&
                project.PropertyStatus.Equals(Project.Status.Execution)) ? Project.Status.Closed : Project.Status.Execution;
        }
    }
}
