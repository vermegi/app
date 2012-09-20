using System;
using System.Collections.Generic;
using System.Linq;

namespace app.utility.container
{
  public class DependencyFactories : IFindFactoriesForDependencies
  {
    IEnumerable<ICreateOneDependency> possible_factories;
    MissingFactory_Behaviour missing_factory_behaviour;

    public DependencyFactories(IEnumerable<ICreateOneDependency> possible_factories,
                               MissingFactory_Behaviour missingFactoryBehaviour)
    {
      this.possible_factories = possible_factories;
      this.missing_factory_behaviour = missingFactoryBehaviour;
    }

    public ICreateOneDependency get_factory_that_can_create(Type dependency)
    {
      var factory = possible_factories.FirstOrDefault(x => x.can_create(dependency));
      if (factory != null) return factory;

      throw missing_factory_behaviour(dependency);
    }
  }
}