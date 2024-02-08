using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    internal abstract class Employee
    {
        public abstract void AccessRestrictedSection();
    }

    [AccessLevel(1)]
    internal class Manager : Employee
    {
        public override void AccessRestrictedSection()
        {
            Console.WriteLine("Manager has access to the restricted section.");
        }
    }


    [AccessLevel(2)]
    internal class Programmer : Employee
    {
        public override void AccessRestrictedSection()
        {
            Console.WriteLine("Programmer has access to the restricted section.");
        }
    }


    [AccessLevel(3)]
    internal class Director : Employee
    {
        public override void AccessRestrictedSection()
        {
            Console.WriteLine("Director has access to the restricted section.");
        }
    }
}
