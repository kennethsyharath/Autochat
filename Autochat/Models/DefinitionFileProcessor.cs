using System.IO;
using YamlDotNet.Serialization;

namespace Autochat.Models
{
    public class DefinitionFileProcessor
    {
        IDeserializer _deserializer;
        LocalPathResolver _pathResolver;
        public DefinitionFileProcessor(IDeserializer deserializer, LocalPathResolver resolver)
        {
            _deserializer = deserializer;
            _pathResolver = resolver;
        }

        public TransitionNode ProcessDefinitionFile(string filePath)
        {
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

            return _deserializer.Deserialize<TransitionNode>(content);
        }
    }
}
