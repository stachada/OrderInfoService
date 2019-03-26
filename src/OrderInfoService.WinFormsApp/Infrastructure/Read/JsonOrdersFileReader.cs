﻿using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using OrderInfoService.WinFormsApp.Core;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace OrderInfoService.WinFormsApp.Infrastructure.Read
{
    public class JsonOrdersFileReader : IOrdersFileReader
    {
        public JsonOrdersFileReader(string path)
        {
            Status = ReaderStatus.Empty;
            if (Path.GetExtension(path) != ".json") Status = ReaderStatus.FileError;

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
                JObject jObject = null;
                try
                {
                    string json = reader.ReadToEnd(); // can be async
                    jObject = JObject.Parse(json);
                }
                catch
                {
                    Status = ReaderStatus.DeserializationError;
                    return null;
                }

                if (!CheckSchema(jObject))
                {
                    Status = ReaderStatus.DeserializationError;
                    return null;
                }

                //List<Order> list = new List<Order>();
                var list = new List<object>();

                foreach (JToken token in jObject.SelectToken("requests"))
                {
                    string clientId = null;

                    if (token["clientId"] != null)
                    {
                        clientId = token["clientId"].ToString();
                    }

                    long? requestId = null;
                    if (token["requestId"] != null)
                    {
                        requestId = ParsingHelpers.ParseLong(token["requestId"].ToString());
                    }

                    string name = null;
                    if (token["name"] != null)
                    {
                        name = token["name"].ToString();
                    }

                    int? quantity = null;
                    if (token["quantity"] != null)
                    {
                        quantity = ParsingHelpers.ParseInt(token["quantity"].ToString());
                    }

                    double? price = null;
                    if (token["price"] != null)
                    {
                        price = ParsingHelpers.ParseDouble(token["price"].ToString());
                    }

                    //var order = new Order(clientId, requestId, name, quantity, price);
                    //list.Add(order);
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

        private bool CheckSchema(JObject jObject)
        {
            string jsonSchema = @"{
                    'description': 'reqeusts',
                    'type': 'object',
                    'properties': {
                        'requests': {
                            'type': 'array',
                            'items': {
                                'type': 'object',
                                'properties': {
                                    'clientId': {'type':'string'},
                                    'requestId': {'type':'string'},
                                    'name': {'type':'string'},
                                    'quantity': {'type':'string'},
                                    'price': {'type':'string'}
                                }
                            }
                        }
                    }
                }";

            JsonSchema schema = JsonSchema.Parse(jsonSchema);
            return jObject.IsValid(schema);
        }
    }
}
