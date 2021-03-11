using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BV1Rf4y147s8
{
    public class FolderViewModel
    {
        private DirectoryInfo Folder;

        public FolderViewModel(string path)
        {
            Folder = new DirectoryInfo(path);
        }

        public string Name => Folder.Name;

        public IEnumerable<FolderViewModel> Children => Folder.GetDirectories().Select(item => new FolderViewModel(item.FullName));
    }
}
