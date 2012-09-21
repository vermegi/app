using System;
using app.utility.container;
using app.web.core;

namespace app.tasks.startup
{
  public class StartupItems
  {
    public class exception_factories
    {
      public static readonly MissingFactory_Behaviour missing_factory = (type) =>
        (Exception)
          not_implemented(String.Format("There is no factory registered that can create a {0}", type.Name), null);

      public static readonly DependencyCreation_Behaviour dependency_creation = (type, inner) =>
        (Exception) not_implemented(String.Format("There was an error attempting to create a {0}", type.Name), inner);

      public static readonly MissingCommandCreation_Behaviour missing_command = () =>
        (IProcessOneRequest) not_implemented("You don't have a command that can run this request", null);

      static object not_implemented(String message, Exception inner)
      {
        throw new NotImplementedException(message, inner);
      }
    }
  }
}