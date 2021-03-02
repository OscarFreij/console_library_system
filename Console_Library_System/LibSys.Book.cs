using System.Xml;

namespace Console_Library_System
{
    public static partial class LibSys
    {
        public static class Book
        {
            public static void Print(int id)
            {

            }

            public static void ChangeAtribute()
            {

            }

            public static void Create(string title, int authorId, string type = "unknown", string ISBN = "")
            {
                XmlElement bookElement = LibSys.Library.xml.CreateElement("book", "https://www.w3schools.com");

                XmlAttribute attribute = LibSys.Library.xml.CreateAttribute("id");
                attribute.Value = LibSys.Library.GetNextBookId().ToString();
                bookElement.Attributes.Append(attribute);

                attribute = LibSys.Library.xml.CreateAttribute("type");
                attribute.Value = type;
                bookElement.Attributes.Append(attribute);

                attribute = LibSys.Library.xml.CreateAttribute("ISBN");
                attribute.Value = ISBN;
                bookElement.Attributes.Append(attribute);

                XmlElement element = LibSys.Library.xml.CreateElement("title", "https://www.w3schools.com");
                element.InnerText = title;
                bookElement.AppendChild(element);

                element = LibSys.Library.xml.CreateElement("author", "https://www.w3schools.com");
                element.InnerText = authorId.ToString();
                bookElement.AppendChild(element);

                element = LibSys.Library.xml.CreateElement("state", "https://www.w3schools.com");
                element.InnerText = "Not Read";
                bookElement.AppendChild(element);

                element = LibSys.Library.xml.CreateElement("reads", "https://www.w3schools.com");
                element.InnerText = "0";
                bookElement.AppendChild(element);
                LibSys.Library.booksNode.AppendChild(bookElement);
                LibSys.Library.SaveLibrary();
            }

            public static void RemoveBook()
            {

            }
        }
    }
}
