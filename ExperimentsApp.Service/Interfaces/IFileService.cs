using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExperimentsApp.Service.Interfaces
{
    public interface IFileService
    {
        void MoveDirectory();
        List<string> GetSubdirs();
    }
}
