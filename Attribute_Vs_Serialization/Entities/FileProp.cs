using System;
using System.IO;
using System.Text;


namespace Attribute_Vs_Serialization.Entities
{
    //класс для создания тестовых файлов
    class FileProp
    {
        public void MakeUser ()
        {
            string file1 = "name.ini";
            string file2 = "date.ini";
            string file3 = "salary.ini";

            using (FileStream fs = new FileStream(file1, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    string propName = "Ivan Petrivich";
                    sw.WriteLine(propName);
                }
            }

            using (FileStream fs = new FileStream(file2, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    DateTime propDate = DateTime.Now;
                    sw.WriteLine(propDate);
                }
            }

            using (FileStream fs = new FileStream(file3, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    int propSalary = 5000;
                    sw.WriteLine(propSalary);
                }
            }
        }
    }
}
