using System;
using System.Reflection;

namespace app.utility.container
{
  public interface IPickTheCtorOnTheTypeToCreate
  {
    ConstructorInfo pick_ctor_from(Type type);
  }
}