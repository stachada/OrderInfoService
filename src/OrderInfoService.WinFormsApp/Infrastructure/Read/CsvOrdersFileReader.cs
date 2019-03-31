using OrderInfoService.WinFormsApp.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OrderInfoService.WinFormsApp.Infrastructure.Read
{
    public class CsvOrdersFileReader : IOrdersFileReader
    {
        private List<string> _schema = new List<string> { "CLIENT_ID", "REQUEST_ID", "NAME", "QUANTITY", "PRICE" };

        public CsvOrdersFileReader(string path)
        {
            Status = ReaderStatus.Empty;
            if (Path.GetExtension(path) != ".csv") Status = ReaderStatus.FileError;

            FilePath = path;
        }

        public ReaderStatus Status { get; private set; }
        public string FilePath { get; private set; }

        public async Task<IList<object>> ReadOrderFileAsync()
        {
            return await Task.Run(() => ReadOrderFile());
        }

        public IList<object> ReadOrderFile()
        {
            if (Status == ReaderStatus.FileError)
                return null;
            if (!File.Exists(FilePath))
            {
                Status = ReaderStatus.FileError;
                return null;
            }

            using (StreamReader reader = new StreamReader(FilePath))
            {
                List<string> columns = Array.ConvertAll(reader.ReadLine().Split(','), item => item.ToUpperInvariant()).ToList();

                if (!CheckSchema(columns))
                {
                    Status = ReaderStatus.DeserializationError;
                    return null;
                }

                //var list = new List<Order>();
                var list = new List<object>();

                while (!reader.EndOfStream)
                {
                    var row = reader.ReadLine().Split(',');

                    string clientId = null;
                    if (columns.IndexOf("CLIENT_ID") != -1 && columns.IndexOf("PRICE") < row.Length)
                    {
                        clientId = row[columns.IndexOf("CLIENT_ID")];
                    }

                    long? requestId = null;
                    if (columns.IndexOf("REQUEST_ID") != -1 && columns.IndexOf("PRICE") < row.Length)
                    {
                        requestId = ParsingHelpers.ParseLong(row[columns.IndexOf("REQUEST_ID")]);
                    }

                    string name = null;
                    if (columns.IndexOf("NAME") != -1 && columns.IndexOf("PRICE") < row.Length)
                    {
                        name = row[columns.IndexOf("NAME")];
                    }

                    int? quantity = null;
                    if (columns.IndexOf("QUANTITY") != -1 && columns.IndexOf("PRICE") < row.Length)
                    {
                        quantity = ParsingHelpers.ParseInt(row[columns.IndexOf("QUANTITY")]);
                    }

                    double? price = null;
                    if (columns.IndexOf("PRICE") != -1 && columns.IndexOf("PRICE") < row.Length)
                    {
                        price = ParsingHelpers.ParseDouble(row[columns.IndexOf("PRICE")]);
                    }
                    
                    list.Add(new
                    {
                        ClientId = clientId,
                        RequestId = requestId,
                        Name = name,
                        Quantity = quantity,
                        Price = price
                    });
                }

                Status = ReaderStatus.Completed;
                return list;
            }
        }

        private bool CheckSchema(List<string> columns)
        {
            foreach (var item in columns)
            {
                if (!_schema.Contains(item.ToUpperInvariant()))
                    return false;
            }
            return true;
        }
    }
}
