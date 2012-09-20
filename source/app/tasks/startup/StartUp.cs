using System;
using System.Collections.Generic;
using app.utility.container;
using app.web.core;
using app.web.core.stubs;

namespace app.tasks.startup
{
  public class StartUp
  {
    static IList<ICreateOneDependency> all_factories = new List<ICreateOneDependency>();

    public static void run()
    {
      GetTheActiveContainer_Behaviour resolution =
        () =>
          new Container(new DependencyFactories(all_factories, StartupItems.exception_factories.missing_factory), 
            StartupItems.exception_factories.dependency_creation);

      Dependencies.container_resolver = resolution;

      all_factories.Add(new DependencyCreator(x => x == typeof(IProcessOneRequest),
        new FunctionalItemFactory(() => new FrontController(Dependencies.fetch.an<IFindCommands>()))));

      all_factories.Add(new DependencyCreator(x => x == typeof(IFindCommands),
        new FunctionalItemFactory(() => new CommandRegistry(Dependencies.fetch.an<IEnumerable<IProcessOneRequest>>(),
          StartupItems.exception_factories.missing_command))));

      all_factories.Add(new DependencyCreator(x => x == typeof(IEnumerable<IProcessOneRequest>),
      new FunctionalItemFactory(() => new StubSetOfCommands()));

    }

    class StartupItems
    {
      public class exception_factories
      {
        public static readonly MissingFactory_Behaviour missing_factory = type =>
        {
          throw new NotImplementedException(string.Format("There is no factory registered that can create a {0}",type.Name));
        };

        public static DependencyCreation_Behaviour dependency_creation = (type, inner) =>
        {
          throw new NotImplementedException(string.Format("There was an error attempting to create a {0}", type.Name), inner);
        };
        public static MissingCommandCreation_Behaviour missing_command = () =>
        {
          throw new NotImplementedException("You don't have a command that can run this request");
        };
      }
    }
  }
}