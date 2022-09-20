using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalChallenges
{
    public class Person
    {
        public string Empresa { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }

        public Dictionary<string, int> AverageAgeByCompany(List<Person> personas)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            var avg = from persona in personas
                      group persona by persona.Empresa into gpe
                      select new
                      {
                          Empresa = gpe.First().Empresa,
                          Edad = gpe.Average(x => x.Edad)
                      };
            foreach (var item in avg)
            {
                result.Add(item.Empresa, Convert.ToInt16(item.Edad));
            }

            return result;
        }

        public List<Person> crearPersonas()
        {
            List<Person> personas = new List<Person>()
            {
                new Person() { Nombre = "Juan", Empresa = "AC", Edad = 25},
                new Person() { Nombre = "Sidny", Empresa = "AC", Edad = 23},
                new Person() { Nombre = "Jashir", Empresa = "AC", Edad = 35},
                new Person() { Nombre = "Manur", Empresa = "AC", Edad = 18},
                new Person() { Nombre = "Baltar", Empresa = "AC", Edad = 47},
                new Person() { Nombre = "Manila", Empresa = "AC", Edad = 37},
                new Person() { Nombre = "Grisal", Empresa = "AC", Edad = 36 },
                new Person() { Nombre = "Rubio", Empresa = "BD", Edad = 24},
                new Person() { Nombre = "Jesus", Empresa = "BD", Edad = 27},
                new Person() { Nombre = "Poliesg", Empresa = "BD", Edad = 32},
                new Person() { Nombre = "Achar", Empresa = "BD", Edad = 27},
                new Person() { Nombre = "Mona", Empresa = "BD", Edad = 46},
                new Person() { Nombre = "Martha", Empresa = "UC", Edad = 57},
                new Person() { Nombre = "Mirtha", Empresa = "UC", Edad = 29},
                new Person() { Nombre = "Elenha", Empresa = "UC", Edad = 29},
                new Person() { Nombre = "Elkar", Empresa = "UC", Edad = 57},
                new Person() { Nombre = "Arthur", Empresa = "KT", Edad = 26},
                new Person() { Nombre = "EL Bicho", Empresa = "KT", Edad = 21},
            };

            return personas;
        }


    }
}
