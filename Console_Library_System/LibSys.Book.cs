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

                InsetWhiteSpace(3, bookElement, element, false);
                InsetWhiteSpace(3, bookElement, element);

                element = LibSys.Library.xml.CreateElement("author", "https://www.w3schools.com");
                element.InnerText = authorId.ToString();
                bookElement.AppendChild(element);


                InsetWhiteSpace(3, bookElement, element);

                element = LibSys.Library.xml.CreateElement("state", "https://www.w3schools.com");
                element.InnerText = "Not Read";
                bookElement.AppendChild(element);


                InsetWhiteSpace(3, bookElement, element);

                element = LibSys.Library.xml.CreateElement("reads", "https://www.w3schools.com");
                element.InnerText = "0";
                bookElement.AppendChild(element);


                InsetWhiteSpace(2, bookElement, element);
                InsetWhiteSpace(2, LibSys.Library.booksNode, LibSys.Library.booksNode.LastChild);
                LibSys.Library.booksNode.AppendChild(bookElement);

                InsetWhiteSpace(1, LibSys.Library.booksNode, LibSys.Library.booksNode.LastChild);
                LibSys.Library.SaveLibrary();

                
            }

            public static void RemoveBook()
            {

            }

            private static void InsetWhiteSpace(int spaces, XmlNode bookElement, XmlNode child, bool after = true, bool lineBreak = true)
            {
                string spaceing = "";

                for (int i = 0; i < spaces; i++)
                {
                    spaceing += "\t";
                }

                XmlWhitespace ws;

                if (lineBreak)
                {
                    ws = LibSys.Library.xml.CreateWhitespace("\r\n" + spaceing);
                }
                else
                {
                    ws = LibSys.Library.xml.CreateWhitespace(spaceing);
                }
                

                if (after)
                {
                    bookElement.InsertAfter(ws, child);
                }
                else
                {
                    bookElement.InsertBefore(ws, child);
                }
            }
        }
    }
}
