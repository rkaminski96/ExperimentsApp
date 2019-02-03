using ExperimentsApp.Data.DAL;
using ExperimentsApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ExperimentsApp.Service.Services
{
    public class FileService : IFileService
    {
        private readonly ExperimentsDbContext _experimentsDbContext;

        public FileService(ExperimentsDbContext experimentsDbContext)
        {
            _experimentsDbContext = experimentsDbContext;
        }

        public void MoveDirectory()
        {
            string sourceDirectory = @"C:\dev\data\incomingData";
            string targetDirectory = @"C:\dev\data\orderedData";

            List<string> subdirs = Directory.GetDirectories(sourceDirectory, "*.*", SearchOption.TopDirectoryOnly).ToList();

            foreach (string dir in subdirs)
            {
                var dirUniqueName = string.Format(@"{0}", DateTime.Now.Ticks);

                DirectoryInfo _dir = new DirectoryInfo(dir);
                _dir.MoveTo(targetDirectory + "\\" + _dir.Name + "_" + dirUniqueName);
            }
        }

        public List<string> GetSubdirs()
        {
            Subdirs subdirs = new Subdirs();
            string directory = @"C:\dev\data\orderedData";
            subdirs.subdirsList = Directory.GetDirectories(directory).ToList();

            return subdirs.subdirsList;
            // string directory = @"C:\dev\data\orderedData";
            // return Directory.GetDirectories(directory).ToList();
        }  
    }
}
 