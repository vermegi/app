using System.Collections;
using System.Collections.Generic;

namespace app.web
{
  public class CommandRegistry : IFindCommands
  {
      private IEnumerable<IProcessOneRequest> possible_commands;

      public CommandRegistry(IEnumerable<IProcessOneRequest> possible_commands)
      {
          this.possible_commands = possible_commands;
      }

      public IProcessOneRequest get_the_command_that_can_process(IEncapsulateRequestDetails request)
      {
          foreach (var command in possible_commands)
          {
              if (command.can_run(request))
                  return command;
          }

          return null;
    }
  }
}