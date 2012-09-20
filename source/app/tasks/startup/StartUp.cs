using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Compilation;
using app.utility.container;
using app.web.core;
using app.web.core.aspnet;
using app.web.core.aspnet.stubs;
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

      all_factories.Add(create_dependency_for<IProcessRequests>(() => new FrontController(Dependencies.fetch.an<IFindCommands>())));
      all_factories.Add(create_dependency_for<IFindCommands>(() => new CommandRegistry(
                                                  Dependencies.fetch.an<IEnumerable<IProcessOneRequest>>(),
                                                  StartupItems.exception_factories.missing_command)));
      all_factories.Add(create_dependency_for<IEnumerable<IProcessOneRequest>>(() => new StubSetOfCommands()));
      all_factories.Add(create_dependency_for<IEnumerable<IDisplayReports>>(() => new WebFormDisplayEngine(
                                                  Dependencies.fetch.an<ICreateDisplayHandlers>(),
                                                  Dependencies.fetch.an<GetTheCurrentlyExecutingRequest_Behaviour>())));
      all_factories.Add(create_dependency_for<GetTheCurrentlyExecutingRequest_Behaviour>(() => HttpContext.Current));
      all_factories.Add(create_dependency_for<ICreateDisplayHandlers>(() => new ASPPageFactory(Dependencies.fetch.an<IFindPathsToLogicalViews>(),
                                                                     BuildManager.CreateInstanceFromVirtualPath)));
      all_factories.Add(create_dependency_for<IFindPathsToLogicalViews>(() => new StubPathRegistry()));
    }

      static ICreateOneDependency create_dependency_for<T>(Func<object> to_create)
      {
          return new DependencyCreator(x => x == typeof (T),
                                       new FunctionalItemFactory(
                                           () => to_create));
      }

      class StartupItems
    {
      public class exception_factories
      {
        public static readonly MissingFactory_Behaviour missing_factory = type =>
        {
          throw new NotImplementedException(string.Format("There is no factory registered that can create a {0}",
                                                          type.Name));
        };

        public static DependencyCreation_Behaviour dependency_creation = (type, inner) =>
        {
          throw new NotImplementedException(string.Format("There was an error attempting to create a {0}", type.Name),
                                            inner);
        };

        public static MissingCommandCreation_Behaviour missing_command = () =>
        {
          throw new NotImplementedException("You don't have a command that can run this request");
        };
      }
    }
  }
}