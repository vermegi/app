using System;

namespace app.utility.container
{
  public class Dependencies
  {
    public static GetTheActiveContainer_Behaviour container_resolver = () =>
    {
      throw new NotImplementedException("This needs to be set by the startup pipeline");
    };

    public static IFetchDependencies fetch
    {
      get { throw new System.NotImplementedException(); }
    }
  }
}