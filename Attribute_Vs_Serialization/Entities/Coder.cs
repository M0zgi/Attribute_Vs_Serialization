using Attribute_Vs_Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Attribute_Vs_Serialization.Entities
{
   // [Params("name.ini", "date.ini", "salary.ini")]
    class Coder
    {
        [Params("name.ini", "date.ini", "salary.ini")]
        
        public string fname { get; set; }
        public string fdate { get; set; }
        public string fsalary { get; set; }


        public string name { get; set; }
        public string date { get; set; }
        public int salary { get; set; }

        public Coder()
        {
            var properties = typeof(Coder).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {

                var attribute = property.GetCustomAttribute<ParamsAttribute>();
                fname = attribute.Name;
                fdate = attribute.Date;
                fsalary = attribute.Salary;
                break;
            }

            
            using (FileStream fs = new FileStream(fname, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                {
                    name = sr.ReadToEnd();
                }
            }

            using (FileStream fs = new FileStream(fdate, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                {
                    date = sr.ReadToEnd();
                }
            }

            using (FileStream fs = new FileStream(fsalary, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                {
                    salary = int.Parse(sr.ReadToEnd().ToString());
                }
            }

        }
        public override string ToString()
        {
            return $"Имя: {name} \nДата приема на работу {date} \nЗраплата {salary}";
        }

    }
}
