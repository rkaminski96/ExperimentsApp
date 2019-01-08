using ExperimentsApp.Data.DAL;
using ExperimentsApp.Service.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace ExperimentsApp.Service.Services
{
    public class FileService : IFileService
    {
        private readonly ExperimentsDbContext _experimentsDbContext;

        public FileService(ExperimentsDbContext experimentsDbContext)
        {
            _experimentsDbContext = experimentsDbContext;
        }

        public string DirectoryPath()
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\data");
            return directory.FullName;
        }
    }
}
