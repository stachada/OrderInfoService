using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OrderInfoService.WinFormsApp.Infrastructure.Write
{
    // https://joshclose.github.io/CsvHelper/getting-started
    public static class OrdersWriter
    {
        public static async Task SaveToCsvAsync<T>(List<T> records, string path)
        {
            await Task.Run(() => SaveToCsv<T>(records, path));
        }

        public static void SaveToCsv<T>(List<T> records, string path)
        {
            using (var writer = new StreamWriter(path, false, Encoding.Unicode))
            using (var csv = new CsvWriter(writer))
            {
                csv.Configuration.Delimiter = ",";
                csv.Configuration.CultureInfo = CultureInfo.InvariantCulture;
                csv.WriteRecords<T>(records);
            }
        }
    }
}
