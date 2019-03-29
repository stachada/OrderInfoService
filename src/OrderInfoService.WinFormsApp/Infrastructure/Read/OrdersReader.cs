using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace OrderInfoService.WinFormsApp.Infrastructure.Read
{
    public class OrdersReader : IOrdersReader
    {
        private Dictionary<string, IOrdersFileReader> _readers = new Dictionary<string, IOrdersFileReader>();

        public OrdersReader()
        {
            _readers = new Dictionary<string, IOrdersFileReader>();
        }

        public async Task<IList<object>> ReadOrdersFromFilesAsync(IEnumerable<string> paths)
        {
            return await Task.Run(() => ReadOrdersFromFiles(paths));
        }

        public IList<object> ReadOrdersFromFiles(IEnumerable<string> paths)
        {
            var tasks = new List<Task<IList<object>>>();
            var orders = new List<object>();
            foreach (var path in paths)
            {
                switch (Path.GetExtension(path))
                {
                    case ".xml":
                        var xmlReader = new XmlOrdersFileReader(path);
                        if (!_readers.ContainsKey(path))
                            _readers.Add(path, xmlReader);
                        tasks.Add(Task.Run(() => xmlReader.ReadOrderFileAsync()));
                        break;
                    case ".json":
                        var jsonReader = new JsonOrdersFileReader(path);
                        if (!_readers.ContainsKey(path))
                            _readers.Add(path, jsonReader);
                        tasks.Add(Task.Run(() => jsonReader.ReadOrderFileAsync()));
                        break;
                    case ".csv":
                        var csvReader = new CsvOrdersFileReader(path);
                        if (!_readers.ContainsKey(path))
                            _readers.Add(path, csvReader);
                        tasks.Add(Task.Run(() => csvReader.ReadOrderFileAsync()));
                        break;
                    default:
                        throw new Exception("Wrong file extension.");
                }
            }

            var continuation = Task.WhenAll(tasks);

            try
            {
                continuation.Wait();
            }
            catch (AggregateException ex)
            {
                throw ex;
            }

            if (continuation.Status == TaskStatus.RanToCompletion)
            {
                foreach (var result in continuation.Result)
                {
                    if (result != null)
                        orders.AddRange(result);
                }
            }
            return orders;
        }

        public List<string> GetLoadedFilesInfo()
        {
            var list = new List<string>();

            foreach (var item in _readers)
            {
                var reader = item.Value as IOrdersFileReader;

                if (reader != null)
                {
                    if (reader.Status == ReaderStatus.Completed)
                    {
                        list.Add($"Plik '{Path.GetFileName(item.Key)}' został zaimportowany.");
                    }
                }
            }

            return list;
        }

        public List<string> GetSkippedFilesInfo()
        {
            var list = new List<string>();

            foreach (var item in _readers)
            {
                var reader = item.Value as IOrdersFileReader;

                if (reader != null)
                {
                    if (reader.Status == ReaderStatus.DeserializationError)
                    {
                        list.Add($"Plik '{Path.GetFileName(item.Key)}' nie został zaimportowany - sprawdź poprawność formatu pliku.");
                    }
                    if (reader.Status == ReaderStatus.FileError)
                    {
                        list.Add($"File '{Path.GetFileName(item.Key)}' nie został zaimportowany - sprawdź czy poprawność ścieżki dostępu.");
                    }
                }
            }

            return list;
        }

        public void Reset()
        {
            _readers.Clear();
        }
    }
}
