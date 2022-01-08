
namespace Publications.ConsoleTests
{
    public partial class Program
    {
        internal class FileSystemVisiter
        {
            public int Visit(FileSystemInfo info)
            {
                Console.WriteLine(info.FullName);

                var linesCount = 0;
                switch (info)
                {
                    case DirectoryInfo dir:

                        foreach(var dir_info in dir.EnumerateFileSystemInfos())
                        {
                            linesCount += Visit(dir_info);
                        }

                        break;
                    case FileInfo { Extension: ".cs" } file:

                        using(var reader = file.OpenText())
                            while (!reader.EndOfStream)
                                if(reader.ReadLine() is { Length: > 0})
                                    linesCount++;

                        Console.WriteLine("Число строк в файле {0}: {1}", info.Name, linesCount);
                        break;
                }

                return linesCount;
            }
        }
    }
}
