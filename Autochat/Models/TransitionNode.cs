using System.Collections.Generic;

namespace Autochat.Models
{
    public class TransitionNode
    {
        public string ContentFilePath { get; set; }

        public List<TransitionDefinition> Transitions { get; set; }
    }
}
