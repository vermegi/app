using System;
using System.Linq;

namespace app.utility.container
{
  public class AutomaticItemFactory: ICreateAnItem
  {
    Type type_to_create;
    IFetchDependencies container;
    IPickTheCtorOnTheTypeToCreate ctor_selector;

    public AutomaticItemFactory(Type type_to_create, IFetchDependencies container, IPickTheCtorOnTheTypeToCreate ctor_selector)
    {
      this.type_to_create = type_to_create;
      this.container = container;
      this.ctor_selector = ctor_selector;
    }

    public object create()
    {
      var ctor = ctor_selector.pick_ctor_from(type_to_create);
      var dependencies = ctor.GetParameters().Select(x => container.an(x.ParameterType));
      return ctor.Invoke(dependencies.ToArray());
    }
  }
}