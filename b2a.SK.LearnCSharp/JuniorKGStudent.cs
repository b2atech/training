using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b2a.SK.SchoolManagement
{
    public class JuniorKGStudent : Student
    {
        public JuniorKGStudent(int id, string firstName, string lastName) : base(id, firstName, lastName)
        {
            this.rollNumber = 1;
        }
    }
}
