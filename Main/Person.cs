using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager
{
    class Person
    {
        protected Random rand = new Random();
        protected string name, surname;
        protected byte age;
        static protected ushort counter = 0;
        protected ushort id = counter;
        public Person()
        {
            counter++;
        }
    }
}
