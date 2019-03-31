using OrderInfoService.WinFormsApp.Core;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace OrderInfoService.WinFormsApp.Infrastructure.Read
{
    public class XmlOrdersFileReader : IOrdersFileReader
    {

        public XmlOrdersFileReader(string path)
        {
            Status = ReaderStatus.Empty;
            if (Path.GetExtension(path) != ".xml") Status = ReaderStatus.FileError;
            FilePath = path;
        }

        public ReaderStatus Status { get; private set; }
        public string FilePath { get; private set; }
        
        public async Task<IList<FlatOrder>> ReadOrderFileAsync()
        {
            return await Task.Run(() => ReadOrderFile());
        }

        public IList<FlatOrder> ReadOrderFile()
        {
            if (Status == ReaderStatus.FileError)
                return null;
            if (!File.Exists(FilePath))
            {
                Status = ReaderStatus.FileError;
                return null;
            }
            XDocument doc;
            try
            {
                doc = XDocument.Load(FilePath);
            }
            catch
            {
                Status = ReaderStatus.DeserializationError;
                return null;
            }

            if (!CheckSchema(doc))
            {
                Status = ReaderStatus.DeserializationError;
                return null;
            }

            var elements = doc.Root.Elements("request");

            if (elements == null)
            {
                Status = ReaderStatus.DeserializationError;
                return null;
            }
            
            var list = new List<FlatOrder>();

            foreach (XElement el in elements)
            {
                string clientId = null;
                if (el.Element("clientId") != null)
                {
                    clientId = (string)el.Element("clientId");
                }

                long? requestId = null;
                if (el.Element("requestId") != null)
                {
                    requestId = ParsingHelpers.ParseLong((string)el.Element("requestId"));
                }

                string name = null;
                if (el.Element("name") != null)
                {
                    name = (string)el.Element("name");
                }

                int? quantity = null;
                if (el.Element("quantity") != null)
                {
                    quantity = ParsingHelpers.ParseInt((string)el.Element("quantity"));
                }

                double? price = null;
                if (el.Element("price") != null)
                {
                    price = ParsingHelpers.ParseDouble((string)el.Element("price"));
                }

                list.Add(new FlatOrder(clientId, requestId, name, quantity, price));
            }

            Status = ReaderStatus.Completed;
            return list;
        }

        private bool CheckSchema(XDocument doc)
        {
            string xsdMarkup =
                @"<?xml version='1.0' encoding='utf-8' ?>  
                  <xsd:schema xmlns:xsd='http://www.w3.org/2001/XMLSchema'>
                    <xsd:element name='requests'>
                            <xsd:complexType>
                                <xsd:sequence>
                                    <xsd:element name='request' maxOccurs='unbounded'>
                                        <xsd:complexType>
                                            <xsd:sequence>
                                                <xsd:element name='clientId' minOccurs='0' maxOccurs='1'/>
                                                <xsd:element name='requestId' minOccurs='0' maxOccurs='1'/>
                                                <xsd:element name='name' minOccurs='0' maxOccurs='1'/>
                                                <xsd:element name='quantity' minOccurs='0' maxOccurs='1'/>
                                                <xsd:element name='price' minOccurs='0' maxOccurs='1'/>
                                            </xsd:sequence>
                                        </xsd:complexType>
                                    </xsd:element>
                                    
                                </xsd:sequence>
                            </xsd:complexType>
                    </xsd:element>
                </xsd:schema>";

            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", XmlReader.Create(new StringReader(xsdMarkup)));
            bool valid = true;
            doc.Validate(schemas, (o, e) =>
            {
                valid = false;
            });
            return valid;
        }
    }
}
