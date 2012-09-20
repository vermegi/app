using System;
using System.Collections.Generic;
using System.Linq;

namespace app.utility.container
{
  public class DependencyFactories : IFindFactoriesForDependencies
  {
    IEnumerable<ICreateOneDependency> possible_factories;

    public DependencyFactories(IEnumerable<ICreateOneDependency> possible_factories)
    {
      this.possible_factories = possible_factories;
    }

    public ICreateOneDependency get_factory_that_can_create(Type dependency)
    {
      return possible_factories.First(x => x.can_create(dependency));
    }
  }
}