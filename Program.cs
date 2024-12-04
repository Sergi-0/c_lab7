using System.Reflection;
using System.Xml;
using ClassLibrary;

namespace lab7_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string OutputFileName = "ClassDiagram.xml"; // имя выходного файла
            XmlDocument xmlDoc = new XmlDocument(); // создаем документ xml формата
            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null); // версия и кодировка
            xmlDoc.AppendChild(xmlDeclaration); // добавляем описание в документ
            XmlElement HeadElement = xmlDoc.CreateElement("ClassDiagram"); // создаем элемент xml формата, который позже добавим в документ
            xmlDoc.AppendChild(HeadElement); // добавляем элемент в документ
            Assembly Assembly = Assembly.Load("ClassLibraryLAB7"); // загрузку сборки (библиотеки)
            Type[] types = Assembly.GetTypes(); // получение всех типов сборки

            foreach (Type type in types)
            {
                XmlElement ClassElement = xmlDoc.CreateElement("Class");
                ClassElement.SetAttribute("name", type.Name);
                object[] attributes = type.GetCustomAttributes(typeof(MyAttribute), false); // false - отвечает за то чтобы, брались аттрибуты именно нашего класса, не включая родительский
                if (attributes.Length > 0)
                {
                    MyAttribute СustomAttribute = (MyAttribute)attributes[0];
                    ClassElement.SetAttribute("Comment", СustomAttribute.Comment);
                }

                PropertyInfo[] Properties = type.GetProperties(); // получаем свойства данного класса
                foreach (PropertyInfo property in Properties)
                {
                    XmlElement PropertyElement = xmlDoc.CreateElement("property");
                    PropertyElement.SetAttribute("name", property.Name);
                    PropertyElement.SetAttribute("type", property.PropertyType.Name);
                    ClassElement.AppendChild(PropertyElement);
                }
                HeadElement.AppendChild(ClassElement);
            }
            xmlDoc.Save(OutputFileName);
        }
    }
}