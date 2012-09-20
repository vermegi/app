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

            register_factorry_for(typeof(IProcessRequests), new FunctionalItemFactory(() => new FrontController(Dependencies.fetch.an<IFindCommands>())));
            register_factorry_for(typeof(IFindCommands), new FunctionalItemFactory(() => new CommandRegistry(Dependencies.fetch.an<IEnumerable<IProcessOneRequest>>(), StartupItems.exception_factories.missing_command)));
            register_factorry_for(typeof(IEnumerable<IProcessOneRequest>), new FunctionalItemFactory(() => new StubSetOfCommands()));
            register_factorry_for(typeof(IDisplayReports), new FunctionalItemFactory(() => new WebFormDisplayEngine(Dependencies.fetch.an<ICreateDisplayHandlers>(), Dependencies.fetch.an<GetTheCurrentlyExecutingRequest_Behaviour>())));
            register_factorry_for(typeof(GetTheCurrentlyExecutingRequest_Behaviour), new FunctionalItemFactory(() => HttpContext.Current));
            register_factorry_for(typeof(ICreateDisplayHandlers), new FunctionalItemFactory(() => new ASPPageFactory(Dependencies.fetch.an<IFindPathsToLogicalViews>(), BuildManager.CreateInstanceFromVirtualPath)));
            register_factorry_for(typeof(IFindPathsToLogicalViews), new FunctionalItemFactory(() => new StubPathRegistry()));
        }

        private static void register_factorry_for(Type type, FunctionalItemFactory functionalItemFactory)
        {
            all_factories.Add(new DependencyCreator(x => x == type, functionalItemFactory));
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