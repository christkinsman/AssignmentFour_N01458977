using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentThree_N01458977.Models
{
    public class Teacher
    {
        //The fields that define a Teacher
        public int TeacherId;
        public string TeacherFname;
        public string TeacherLname;
        public string EmployeeNumber;
        public DateTime HireDate;
        public float Salary;
        public string TeacherClass;

        //parameter-less constructor function
        public Teacher() { }
    }
}