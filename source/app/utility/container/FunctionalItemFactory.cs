using System;

namespace app.utility.container
{
  public class FunctionalItemFactory : ICreateAnItem
  {
    Func<object> creation;

    public FunctionalItemFactory(Func<object> creation)
    {
      this.creation = creation;
    }

    public object create()
    {
      return creation();
    }
  }
}