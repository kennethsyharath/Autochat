using Autochat.Models;

namespace Autochat.Controls
{
    class PrintOnTransitionHandler
    {
        ContentFileProcessor _processor;
        ContentPrinter _printer;
        public PrintOnTransitionHandler(ContentFileProcessor fileProcessor, ContentPrinter printer)
        {
            _processor = fileProcessor;
            _printer = printer;
        }

        //This is where we would do the preprocessing and data injection.
        public void PrintContent(TransitionNode node)
        {
            System.Threading.Thread.Sleep(250);

            var content = _processor.GetContentFileContents(node.ContentFilePath);

            if (content != null)
                _printer.PrintContent(content);
        }
    }
}
