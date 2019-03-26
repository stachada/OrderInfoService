using System.Collections.Generic;

namespace OrderInfoService.WinFormsApp.Infrastructure.Read
{
    public interface IOrdersReader
    {
        List<string> GetLoadedFilesInfo();
        List<string> GetSkippedFilesInfo();
        IList<object> ReadOrdersFromFiles(IEnumerable<string> paths);
        void Reset();
    }
}