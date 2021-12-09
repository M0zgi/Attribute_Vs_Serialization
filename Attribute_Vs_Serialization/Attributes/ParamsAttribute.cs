using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attribute_Vs_Serialization.Attributes
{
    //Создать атрибут, который должен быть применен только к свойствам класса
    [AttributeUsage(AttributeTargets.Property)]

    //[AttributeUsage(AttributeTargets.All)]
    public class ParamsAttribute : System.Attribute
    {
        private readonly string fName;
        private readonly string fDate;
        private readonly string fSalary;

        public string Name
        {
            get { return fName; }
        }

        public string Date
        {
            get { return fDate; }
        }

        public string Salary
        {
            get { return fSalary; }
        }

        public ParamsAttribute() { }
        public ParamsAttribute(string name, string date, string salary)
        {
            try
            {
                fName = name;
                fDate = date;
                fSalary = salary;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override string ToString()
        {
            return $"Name: {fName}, Date {fDate}, Salary {fSalary}";
        }
    }
}
