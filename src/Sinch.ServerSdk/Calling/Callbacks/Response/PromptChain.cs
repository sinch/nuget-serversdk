using System.Collections.Generic;
using System.Linq;

namespace Sinch.ServerSdk.Calling.Callbacks.Response
{
    public class PromptChain : Prompt
    {
        public PromptChain(IEnumerable<Prompt> prompts)
        {
            Specification = string.Join(";", prompts.Where(p => !string.IsNullOrEmpty(p.Specification)).Select(p => p.Specification));
        }
    }
}
