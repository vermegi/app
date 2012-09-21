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
        static readonly IList<ICreateOneDependency> all_factories = new List<ICreateOneDependency>();

        public static void run()
        {
            GetTheActiveContainer_Behaviour resolution = 
                () => new Container(new DependencyFactories(all_factories, StartupItems.exception_factories.missing_factory), StartupItems.exception_factories.dependency_creation);

            Dependencies.container_resolver = resolution;
            register<IProcessRequests>(() => new FrontController(depending_on<IFindCommands>()));
            register<IFindCommands>(() => new CommandRegistry(depending_on<IEnumerable<IProcessOneRequest>>(), StartupItems.exception_factories.missing_command));
            register<IEnumerable<IProcessOneRequest>>(() => new StubSetOfCommands());
            register<IDisplayReports>(() => new WebFormDisplayEngine(depending_on<ICreateDisplayHandlers>(), depending_on<GetTheCurrentlyExecutingRequest_Behaviour>()));
            register<GetTheCurrentlyExecutingRequest_Behaviour>(() => HttpContext.Current);
            register<ICreateDisplayHandlers>(() => new ASPPageFactory(depending_on<IFindPathsToLogicalViews>(), BuildManager.CreateInstanceFromVirtualPath));
            register<IFindPathsToLogicalViews>(() => new StubPathRegistry());
        }

        private static dependency depending_on<dependency>()
        {
            return Dependencies.fetch.an<dependency>();
        }

        private static void register<InterFace>(Func<object> creation)
        {
            all_factories.Add(new DependencyCreator(x => x == typeof(InterFace), new FunctionalItemFactory(creation)));
        }

        class StartupItems
        {
            public class exception_factories
            {
                public static readonly MissingFactory_Behaviour missing_factory = (type) => 
                    (Exception)not_implemented(string.Format("There is no factory registered that can create a {0}", type.Name), null);
                
                public static readonly DependencyCreation_Behaviour dependency_creation = (type, inner) => 
                    (Exception)not_implemented(string.Format("There was an error attempting to create a {0}", type.Name), inner);
                
                public static readonly MissingCommandCreation_Behaviour missing_command = () => 
                    (IProcessOneRequest)not_implemented("You don't have a command that can run this request", null);
               
                private static object not_implemented(String message,Exception inner)
                {
                    throw new NotImplementedException(message, inner);
                }
            }
        }
    }
}