using ExperimentsApp.Data.DAL;
using ExperimentsApp.Service.Interfaces;

namespace ExperimentsApp.Service.Services
{
    public class FileService : IFileService
    {
        private readonly ExperimentsDbContext _experimentsDbContext;

        public FileService(ExperimentsDbContext experimentsDbContext)
        {
            _experimentsDbContext = experimentsDbContext;
        }


    }
}
