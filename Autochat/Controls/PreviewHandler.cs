using Autochat.Models;

namespace Autochat.Controls
{
    class PreviewHandler
    {
        PreviewData _previewDataModel;
        ContentFileProcessor _contentFileProcessor;
        DefinitionFileProcessor _definitionFileProcessor;

        public PreviewHandler(PreviewData data, ContentFileProcessor contentFileProcessor, 
            DefinitionFileProcessor definitionFileProcessor)
        {
            _previewDataModel = data;
            _contentFileProcessor = contentFileProcessor;
            _definitionFileProcessor = definitionFileProcessor;
        }

        public void UpdatePreviewData(TransitionNode node)
        {
            _previewDataModel.Clear();
            _previewDataModel.Add(("Control+Alt+P",
                _contentFileProcessor.GetContentFileContents(node.ContentFilePath)));


            foreach (var t in node.Transitions)
            {
                var tNode = _definitionFileProcessor.ProcessDefinitionFile(t.DefFilePath);
                var tContent = _contentFileProcessor.GetContentFileContents(tNode.ContentFilePath);
                _previewDataModel.Add((t.Trigger, tContent));
            }

            _previewDataModel.MarkUpdated();
        }
    }
}
