using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Zadatci345
{
    class Program
    {
        static void Main(string[] args)
        {
            //Zadatak3
            int[] integers = new[] { 1, 2, 2, 2, 3, 3, 4, 5 };
            string[] strings = integers.ToList().GroupBy(i => i).Select(grp =>new StringBuilder().Append("Broj " + grp.Key.ToString() + " ponavlja se " + grp.Count() + " puta.").ToString()).ToArray();

            
            for(int i = 0; i < strings.Length; i++)
            {
                Console.WriteLine(strings[i]);
            }
                Console.ReadLine();
            

           
            Example1();
            Example2();
           

            
            University [] universities = GetAllCroatianUniversities ();
            Student[] allCroatianStudents = universities.SelectMany(x => x.Students).ToList().Distinct().ToArray();
            Student[] croatianStudentsOnMultipleUniversities = universities.SelectMany(x => x.Students).ToList().GroupBy(x => x).Where(g => g.Count() > 1).Select(y => y.Key).ToArray();
            

             

        }

        private static University[] GetAllCroatianUniversities()
        {
            throw new NotImplementedException();
        }

        static void Example1()
        {
            var list = new List<Student>()
            {
                new Student (" Ivan ", jmbag :" 001234567 ")
            };
            var ivan = new Student(" Ivan ", jmbag: " 001234567 ");
            // false :(
            bool anyIvanExists = list.Any(s => s == ivan);
            Console.WriteLine(anyIvanExists);
            Console.ReadLine();
        }
        static void Example2()
        {
            var list = new List<Student>()
            {
                new Student (" Ivan ", jmbag :" 001234567 "),
                new Student (" Ivan ", jmbag :" 001234567 ")
                };
            // 2 :(
            var distinctStudents = list.Distinct().Count();
            Console.WriteLine(distinctStudents);
            Console.ReadLine();
        }
    }
}
