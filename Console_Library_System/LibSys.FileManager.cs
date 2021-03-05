using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace Console_Library_System
{
    public static partial class LibSys
    {
        public static string LibName = "Lib1";
        public static string SchemaName = "LibValidationSchema";
        public static class FileManager
        {
            public static void Init()
            {

            }

            public static void GenDoc()
            {

            }
            public static XmlDocument LoadDoc()
            {
                XmlReader reader;

                XmlReaderSettings settings = new XmlReaderSettings();

                // Helper method to retrieve schema.
                XmlSchema schema = getXMLSchema();

                if (schema == null)
                {
                    return null;
                }

                settings.Schemas.Add(schema);

                settings.ValidationEventHandler += settings_ValidationEventHandler;
                settings.ValidationFlags = settings.ValidationFlags | XmlSchemaValidationFlags.ReportValidationWarnings;
                settings.ValidationType = ValidationType.Schema;

                try
                {
                    reader = XmlReader.Create(Directory.GetCurrentDirectory() + "/Collections/"+LibName+".xml", settings);
                }
                catch (System.IO.FileNotFoundException)
                {
                    return null;
                }

                XmlDocument doc = new XmlDocument();
                doc.PreserveWhitespace = false;
                doc.Load(reader);
                reader.Close();

                return doc;
            }

            private static XmlSchema getXMLSchema()
            {
                XmlSchemaSet xs = new XmlSchemaSet();
                XmlSchema schema;
                try
                {
                    schema = xs.Add("https://www.w3schools.com", Directory.GetCurrentDirectory() + "/Config/"+SchemaName+".xsd");
                }
                catch (System.IO.FileNotFoundException)
                {
                    return null;
                }
                return schema;
            }

            private static void validateXML(XmlDocument doc)
            {
                if (doc.Schemas.Count == 0)
                {
                    // Helper method to retrieve schema.
                    XmlSchema schema = getXMLSchema();
                    doc.Schemas.Add(schema);
                }

                // Use an event handler to validate the XML node against the schema.
                doc.Validate(settings_ValidationEventHandler);
            }

            private static void settings_ValidationEventHandler(object sender, System.Xml.Schema.ValidationEventArgs e)
            {
                if (e.Severity == XmlSeverityType.Warning)
                {
                    Console.WriteLine("The following validation warning occurred: " + e.Message);
                }
                else if (e.Severity == XmlSeverityType.Error)
                {
                    Console.WriteLine("The following critical validation errors occurred: " + e.Message);
                }
            }

            public static void SaveDoc(XmlDocument doc)
            {
                validateXML(doc);
                var output = System.Xml.Linq.XDocument.Parse(doc.OuterXml);
                output.Save(Directory.GetCurrentDirectory() + "/Collections/" + LibName + ".xml");
            }
        }
    }
}
