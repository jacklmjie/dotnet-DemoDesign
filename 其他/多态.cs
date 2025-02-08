using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace DemoDesign.其他
{
    enum FileType
    {
        Doc,
        Img
    }

    interface IFileOpen
    {
        void Open();
    }

    abstract class Files : IFileOpen
    {
        private FileType _fileType;
        public FileType FileType { get { return _fileType; } }

        protected void SetFileType(FileType fileType)
        {
            _fileType = fileType;
        }

        public abstract void Open();
    }

    abstract class DocFile : Files
    {
        protected DocFile()
        {
            SetFileType(FileType.Img);
        }

        public int GetPageCount()
        {
            return 0;
        }
    }

    class WorldFile : DocFile
    {
        public override void Open()
        {
            Console.WriteLine("open the world file.");
        }
    }

    abstract class ImageFile : Files
    {
        protected ImageFile()
        {
            SetFileType(FileType.Doc);
        }

        public void ZoomIn() { }

        public void ZoomOut() { }
    }

    class LoadManager
    {
        private IList<Files> files = new List<Files>();

        public IList<Files> Files { get { return files; } }

        public void LoadFiles(Files file)
        {
            files.Add(file);
        }

        public void OpenAllFiles()
        {
            foreach (Files file in files)
            {
                file.Open();
            }
        }

        public void OpenFile(IFileOpen file)
        {
            file.Open();
        }

        public FileType GetFileTypes(string fileName)
        {
            FileInfo fi = new FileInfo(fileName);
            return (FileType)Enum.Parse(typeof(FileType), fi.Extension);
        }
    }

    public class FileClient
    {
        [Fact]
        public void Test()
        {
            LoadManager lm = new LoadManager();

            lm.LoadFiles(new WorldFile());
            //lm.LoadFiles(new PdfFile());
            //lm.LoadFiles(new JpgFile());

            foreach (Files file in lm.Files)
            {
                if (file.FileType is FileType.Doc)
                {
                    lm.OpenFile(file);
                }
            }
        }
    }
}
