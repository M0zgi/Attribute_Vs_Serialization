using Attribute_Vs_Serialization.Attributes;
using Attribute_Vs_Serialization.Entities;
using System;
using System.IO;
using System.Reflection;
using System.Text;



namespace Attribute_Vs_Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            FileProp file = new FileProp();

            file.MakeUser();
            Coder coder = new Coder();
            Console.WriteLine(coder);
        }
    }
}
