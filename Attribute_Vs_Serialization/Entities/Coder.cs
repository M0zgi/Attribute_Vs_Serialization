using Attribute_Vs_Serialization.Attributes;
using System;
using System.IO;
using System.Reflection;
using System.Text;


namespace Attribute_Vs_Serialization.Entities
{
   // [Params("name.ini", "date.ini", "salary.ini")]
    class Coder
    {
        [Params("name.ini", "date.ini", "salary.ini")]
        
        //имена файлов для считывания данных для свойств
        public string fname { get; set; }
        public string fdate { get; set; }
        public string fsalary { get; set; }


        //свойства объекта
        public string name { get; set; }
        public DateTime date { get; set; }
        public int salary { get; set; }

        //быстрая версия проверки работы атрибутов, создание сущности с заранее созданными файлами и данными в них
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
                    name = sr.ReadLine();
                }
            }

            using (FileStream fs = new FileStream(fdate, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                {
                    date = DateTime.Parse(sr.ReadLine());
                }
            }

            using (FileStream fs = new FileStream(fsalary, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                {
                    salary = int.Parse(sr.ReadLine());
                }
            }
        }
        public override string ToString()
        {
            return $"Имя: {name} \nДата приема на работу {date} \nЗраплата {salary}";
        }

    }
}
