using System;
using System.Runtime.Serialization;

namespace Attribute_Vs_Serialization.CustomSerialization
{
    [Serializable]
    public class Car : ISerializable
    {
        public string name;
        public int speed;

        public Car(string name, int speed)
        {
            this.name = name;
            this.speed = speed;
        }

        //этот конструктор нужен для вызова XmlSerializer xmlFormat = new XmlSerializer(typeof(Car));
        //без этого конструткора Exception Car cannot be serialized because it does not have a parameterless constructor.
        private Car(){}

        private Car(SerializationInfo info, StreamingContext context)
        {
            name = info.GetString("name");
            speed = info.GetInt32("speed");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name", name);
            info.AddValue("speed", speed);
        }

        public override string ToString()
        {
            return $"Модель машины: {name} \nСкорость: {speed}"; 
        }
    }
}
