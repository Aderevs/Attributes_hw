using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    internal class AccessLevelAttribute : Attribute
    {
        public int Level { get; }

        public AccessLevelAttribute(int level)
        {
            Level = level;
        }
    }
}
