using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderInfoService.WinFormsApp.Infrastructure.Read
{
    public interface IOrdersReader
    {
        List<string> GetLoadedFilesInfo();
        List<string> GetSkippedFilesInfo();
        IList<object> ReadOrdersFromFiles(IEnumerable<string> paths);
        Task<IList<object>> ReadOrdersFromFilesAsync(IEnumerable<string> paths);
        void Reset();
    }
}