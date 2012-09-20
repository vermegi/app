using System;
using System.Collections.Generic;
using System.Linq;

namespace app.utility.container
{
  public class DependencyFactories : IFindFactoriesForDependencies
  {
    IEnumerable<ICreateOneDependency> possible_factories;
      private MissingFactory_Behaviour missingFactoryBehaviour;

    public DependencyFactories(IEnumerable<ICreateOneDependency> possible_factories, MissingFactory_Behaviour missingFactoryBehaviour)
    {
        this.possible_factories = possible_factories;
        this.missingFactoryBehaviour = missingFactoryBehaviour;
    }

      public ICreateOneDependency get_factory_that_can_create(Type dependency)
      {
          var factory = possible_factories.FirstOrDefault(x => x.can_create(dependency));
          if(factory != null)
            return factory;

          throw missingFactoryBehaviour(dependency);
      }
  }
}