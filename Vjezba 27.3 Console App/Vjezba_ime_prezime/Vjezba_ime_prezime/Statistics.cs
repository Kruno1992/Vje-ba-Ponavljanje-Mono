using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba_ime_prezime
{
    public class Statistics
    {
        public List<Person> People { get; set; }

        public Statistics(List<Person> people)
        {
            People = people;
        }

        public Person GetEldestPerson()
        {
            return People.OrderByDescending(p => p.DateOfBirth).First();
        }

        public Person GetYoungestPerson()
        {
            return People.OrderBy(p => p.DateOfBirth).First();
        }

        public int GetNumberOfMales()
        {
            return People.Count(p => p.Sex == "M");
        }

        public int GetNumberOfFemales()
        {
            return People.Count(p => p.Sex == "F");
        }

        public int GetNumberOfPeopleBornBeforeYear(int year)
        {
            return People.Count(p => p.DateOfBirth.Year < year);
        }
    }

}
