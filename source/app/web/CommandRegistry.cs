using System.Collections.Generic;
using System.Linq;

namespace app.web
{
  public class CommandRegistry : IFindCommands
  {
      private IEnumerable<IProcessOneRequest> all_commands;
      private MissingCommandCreation_Behaviour missingCommandhaBehaviour;

      public CommandRegistry(IEnumerable<IProcessOneRequest> processList, MissingCommandCreation_Behaviour missingCommandhaBehaviour)
      {
          all_commands = processList;
          this.missingCommandhaBehaviour = missingCommandhaBehaviour;
      }

      public IProcessOneRequest get_the_command_that_can_process(IEncapsulateRequestDetails request)
      {
          var theCommandThatCanProcess = all_commands.SingleOrDefault(process => process.can_run(request));
          return theCommandThatCanProcess ?? missingCommandhaBehaviour.Invoke();
      }
  }
}