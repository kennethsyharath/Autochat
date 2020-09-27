using System.Diagnostics;

namespace Autochat.Models
{
    public class LocalPathResolver
    {
        public string TargetDirectory { get; protected set; }

        public void SetDirectoryFromFilePath(string filePath)
        {
            Debug.WriteLine("inPath: " + filePath);
            SetDirectory(System.IO.Path.GetDirectoryName(filePath));
            Debug.WriteLine($"result dir: " + TargetDirectory);
        }

        public void SetDirectory(string dirPath) => TargetDirectory = dirPath;
    }
}