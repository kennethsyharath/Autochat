using System.Diagnostics;
using System.IO;

namespace Autochat.Models
{
    public class ContentFileProcessor
    {
        LocalPathResolver _pathResolver;
        public ContentFileProcessor(LocalPathResolver pathResolver)
        {
            _pathResolver = pathResolver;
        }

        public string GetContentFileContents(string filePath)
        {
            Debug.WriteLine($"Attempting to read filepath: {filePath}");

            string content = null;

            if (File.Exists(filePath))
            {
                content = File.ReadAllText(filePath);
            }
            else
            {
                var filePaths = Directory.GetFiles(_pathResolver.TargetDirectory,
                    filePath, SearchOption.AllDirectories);

                if (filePaths.Length > 0)
                    content = File.ReadAllText(filePaths[0]);
            }

            return content;
        }
    }
}
