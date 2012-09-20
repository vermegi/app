using System;

namespace app.utility.container
{
  public interface ICreateOneDependency
  {
    object create();
    bool can_create(Type dependency);
  }
}