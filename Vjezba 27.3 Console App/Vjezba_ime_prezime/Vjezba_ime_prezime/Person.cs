using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba_ime_prezime
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Sex { get; set; }

        public Person(string name, string surname, DateTime dateOfBirth, string sex)
        {
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            Sex = sex;
        }
    }

}
