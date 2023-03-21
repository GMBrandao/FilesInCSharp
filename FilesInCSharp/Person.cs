using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesInCSharp
{
    internal class Person
    {
        public string Name { get; set; }
        public char Gender { get; set; }
        
        public Person(string n, char g) 
        {
            Name = n;
            Gender = g;
        }

        public override string ToString()
        {
            return $"Nome: {this.Name} | Gênero: {this.Gender}";
        }
    }
}
