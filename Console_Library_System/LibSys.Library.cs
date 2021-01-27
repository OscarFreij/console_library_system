using System.Collections.Generic;
using System.Xml;

namespace Console_Library_System
{
    public static partial class LibSys
    {
        public static class Library
        {
            public static XmlDocument xml { get; private set; }
            public static XmlNamespaceManager nsmgr { get; private set; }
            public static XmlNode booksNode { get; private set; }
            public static XmlNode authorsNode { get; private set; }
            public static XmlNode configNode { get; private set; }

            private static int nextAuthorId { get; set; }
            private static int nextBookId { get; set; }

            public static void LoadLibrary(XmlDocument a)
            {
                xml = a;

                string xmlns = xml.DocumentElement.Attributes["xmlns"].Value;
                nsmgr = new XmlNamespaceManager(xml.NameTable);
                nsmgr.AddNamespace("LibSys", xmlns);

                booksNode = xml.SelectSingleNode("/LibSys:library/LibSys:books", nsmgr);
                authorsNode = xml.SelectSingleNode("/LibSys:library/LibSys:authors", nsmgr);
                configNode = xml.SelectSingleNode("/LibSys:library/LibSys:config", nsmgr);

                nextAuthorId = int.Parse(configNode.SelectSingleNode("./LibSys:nextAuthorId", nsmgr).InnerText);
                nextBookId = int.Parse(configNode.SelectSingleNode("./LibSys:nextBookId", nsmgr).InnerText);
            }

            public static void SaveLibrary()
            {
                LibSys.FileManager.SaveDoc(xml);
            }

            public static int GetNextAuthorId()
            {
                int returnInt = nextAuthorId;
                nextAuthorId++;
                configNode.SelectSingleNode("./LibSys:nextAuthorId", nsmgr).InnerText = nextAuthorId.ToString();
                return returnInt;
            }

            public static int GetNextBookId()
            {
                int returnInt = nextBookId;
                nextBookId++;
                configNode.SelectSingleNode("./LibSys:nextBookId", nsmgr).InnerText = nextBookId.ToString();
                return returnInt;
            }
        }
    }
}
