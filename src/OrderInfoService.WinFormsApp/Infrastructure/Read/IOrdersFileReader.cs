using OrderInfoService.WinFormsApp.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderInfoService.WinFormsApp.Infrastructure.Read
{
    public interface IOrdersFileReader
    {
        Task<IList<FlatOrder>> ReadOrderFileAsync();
        IList<FlatOrder> ReadOrderFile();
        ReaderStatus Status { get; }
        string FilePath { get; }
    }
}
