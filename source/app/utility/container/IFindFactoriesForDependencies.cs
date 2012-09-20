using System;

namespace app.utility.container
{
  public interface IFindFactoriesForDependencies
  {
    ICreateOneDependency get_factory_that_can_create(Type dependency);
  }
}