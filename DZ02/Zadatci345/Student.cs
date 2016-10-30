using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatci345
{
    public enum Gender
    {
        Male, Female
    }

    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }
        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public static bool operator == (Student obj1, Student obj2)
        {
            return obj1.Equals(obj2);
        }

        public static bool operator !=(Student obj1, Student obj2)
        {
            return !obj1.Equals(obj2);
        }

        public override bool Equals(object obj)
        {
            if(obj == null || !(obj.GetType() == typeof(Student)))
            {
                return false;
            }
            if (this.Jmbag.Equals(((Student) obj).Jmbag))
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Jmbag.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            return sb.Append(this.Name + " " + this.Jmbag + " " + this.Gender).ToString();
        }
    }
}

