using System;

namespace app.utility.container
{
  public class DependencyFactories: IFindFactoriesForDependencies
  {
    public ICreateOneDependency get_factory_that_can_create(Type dependency)
    {
      throw new NotImplementedException();
    }
  }
}