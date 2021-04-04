using System;
using System.IO;

namespace full_game.res
{
    class FileManager
    {
        public void addFile(string name, string path, string projname)
        {
            File.Create(path + "/" + projname + "/" + name);
        }
        public void addFolder(string name, string path, string projname)
        {
            Directory.CreateDirectory(path + "/" + projname + name);
        }
    }
}
