using System;

namespace app.utility.container
{
  public class Container : IFetchDependencies
  {
    IFindFactoriesForDependencies factories;
    DependencyCreation_Behaviour exception_creation_behaviour;

    public Container(IFindFactoriesForDependencies factories,
                     DependencyCreation_Behaviour exception_creation_behaviour)
    {
      this.factories = factories;
      this.exception_creation_behaviour = exception_creation_behaviour;
    }

    public Collaborator an<Collaborator>()
    {
      return (Collaborator) an(typeof(Collaborator));
    }

    public object an(Type collaborator)
    {
      try
      {
        var factory = factories.get_factory_that_can_create(collaborator);
        return factory.create();
      }
      catch (Exception e)
      {
        throw exception_creation_behaviour(collaborator, e);
      }
    }
  }
}