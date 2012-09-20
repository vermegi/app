using System;

namespace app.utility.container
{
  public interface IFetchDependencies
  {
    Collaborator an<Collaborator>();
    object an(Type collaborator);
  }
}