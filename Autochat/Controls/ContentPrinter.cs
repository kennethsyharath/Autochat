using System.Diagnostics;
using System.Windows.Forms;

namespace Autochat.Controls
{
    public class ContentPrinter
    {
        public void PrintContent(string content)
        {
            Debug.WriteLine($"Attempting to write content: {content}");
            Clipboard.SetText(content);
            SendKeys.Send("^V");
        }
    }
}
