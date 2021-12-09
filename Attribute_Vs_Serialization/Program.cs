using Attribute_Vs_Serialization.CustomSerialization;
using Attribute_Vs_Serialization.Entities;
using System;
using System.IO;
using System.Xml.Serialization;

namespace Attribute_Vs_Serialization
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Задание #1

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("AttributeUsage(AttributeTargets.Property)");
            Console.ResetColor();


            FileProp file = new FileProp();

            file.MakeUser();
            Coder coder = new Coder();
            Console.WriteLine(coder);
            Console.WriteLine();
            #endregion

            Console.WriteLine(new string('-', 20));


            #region Задание #2* Использование словаря для Сериализации

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Serializable : ISerializable");
            Console.ResetColor();
            Car car = new Car("KIA", 240);

            Console.WriteLine(car);

            XmlSerializer xmlFormat = new XmlSerializer(typeof(Car));

            try
            {
                using (Stream fStream = File.Create("car.xml"))
                {
                    xmlFormat.Serialize(fStream, car);
                }

                Console.WriteLine("XmlSerialize OK!\n");

                car = null;

                using (Stream fStream = File.OpenRead("car.xml"))
                {
                    car = (Car)xmlFormat.
                    Deserialize(fStream);
                }

                Console.WriteLine(new string('-', 20));

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Deserialize");
                Console.ResetColor();
                Console.WriteLine(car);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }

            #endregion

        }
    }
}
