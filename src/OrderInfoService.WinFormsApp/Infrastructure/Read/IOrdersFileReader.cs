using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderInfoService.WinFormsApp.Infrastructure.Read
{
    public interface IOrdersFileReader
    {
        Task<IList<object>> ReadOrderFileAsync();
        IList<object> ReadOrderFile();
        ReaderStatus Status { get; }
        string FilePath { get; }
    }
}
