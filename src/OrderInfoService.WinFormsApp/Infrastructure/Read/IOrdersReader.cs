using OrderInfoService.WinFormsApp.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderInfoService.WinFormsApp.Infrastructure.Read
{
    public interface IOrdersReader
    {
        List<string> GetLoadedFilesInfo();
        List<string> GetSkippedFilesInfo();
        IList<FlatOrder> ReadOrdersFromFiles(IEnumerable<string> paths);
        Task<IList<FlatOrder>> ReadOrdersFromFilesAsync(IEnumerable<string> paths);
        void Reset();
    }
}