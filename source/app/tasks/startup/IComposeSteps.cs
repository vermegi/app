using System.Collections.Generic;

namespace app.tasks.startup
{
    public interface IComposeSteps
    {
        IEnumerable<ITakePartInStartup> Steps { get; set; }
    }
}