using System;
using System.Collections.Generic;

namespace app.utility.container
{
  public class DependencyFactories: IFindFactoriesForDependencies
  {
      IEnumerable<ICreateOneDependency> possible_factories;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:System.Object"/> class.
      /// </summary>
      public DependencyFactories(IEnumerable<ICreateOneDependency> possible_factories)
      {
          this.possible_factories = possible_factories;
      }

      public ICreateOneDependency get_factory_that_can_create(Type dependency)
    {
          foreach (var factory in possible_factories)
          {
              if (factory.can_create(dependency))
                  return factory;
          }

          throw new ArgumentException("couldn't find the factory.");
    }
  }
}