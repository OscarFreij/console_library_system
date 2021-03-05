using System;
using System.Xml;

namespace Console_Library_System
{
    public static partial class LibSys
    {
        public static class Author
        {
            public static void Print(int id)
            {
                if (id != -1)
                {
                    XmlNode node = LibSys.Library.authorsNode.SelectSingleNode($"//LibSys:author[@id='{id}']", LibSys.Library.nsmgr);
                    if (node == null)
                    {
                        Console.WriteLine("ERROR: No author with that id!");
                    }
                    else
                    {
                        Console.WriteLine("#===#===#===#===#");
                        foreach (XmlNode subNode in node.ChildNodes)
                        {
                            Console.WriteLine(subNode.Name + " | " + subNode.InnerText);
                        }
                        Console.WriteLine("#===#===#===#===#");
                    }
                    return;
                }
                else
                {
                    XmlNodeList nodes = LibSys.Library.authorsNode.SelectNodes($"//LibSys:author[@id]", LibSys.Library.nsmgr);
                    Console.WriteLine("#===#===#===#===#");
                    foreach (XmlNode node in nodes)
                    {
                        Console.WriteLine("¤---¤---¤---¤---¤");
                        foreach (XmlNode subNode in node.ChildNodes)
                        {
                            Console.WriteLine(subNode.Name + " | " + subNode.InnerText);
                        }
                    }
                    Console.WriteLine("¤---¤---¤---¤---¤");
                    Console.WriteLine("#===#===#===#===#");
                    return;
                }
            }

            public static void ChangeAtribute()
            {

            }

            public static void Create(string firstname, string sirname)
            {
                XmlElement bookElement = LibSys.Library.xml.CreateElement("author", "https://www.w3schools.com");

                XmlAttribute attribute = LibSys.Library.xml.CreateAttribute("id");
                attribute.Value = LibSys.Library.GetNextAuthorId().ToString();
                bookElement.Attributes.Append(attribute);

                XmlElement element = LibSys.Library.xml.CreateElement("firstname", "https://www.w3schools.com");
                element.InnerText = firstname;
                bookElement.AppendChild(element);

                element = LibSys.Library.xml.CreateElement("sirname", "https://www.w3schools.com");
                element.InnerText = sirname;
                bookElement.AppendChild(element);

                LibSys.Library.authorsNode.AppendChild(bookElement);
                LibSys.Library.SaveLibrary();
            }

            public static void Remove(int id)
            {
                XmlNode node = LibSys.Library.authorsNode.SelectSingleNode($"//LibSys:author[@id='{id}']", LibSys.Library.nsmgr);

                if (node != null)
                {
                    LibSys.Library.authorsNode.RemoveChild(node);
                    LibSys.Library.SaveLibrary();
                }
                else
                {
                    Console.WriteLine("ERROR: node with id of " + id + " not found i xml");
                }
            }
        }
    }
}
