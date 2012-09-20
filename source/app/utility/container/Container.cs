using System;

namespace app.utility.container
{
  public class Container : IFetchDependencies
  {
    IFindFactoriesForDependencies factories;
      DependencyCreationExceptionFactory_Behaviour exception_creation_behaviour;

    public Container(IFindFactoriesForDependencies factories, DependencyCreationExceptionFactory_Behaviour exceptionCreationBehaviour)
    {
        this.factories = factories;
        exception_creation_behaviour = exceptionCreationBehaviour;
    }

      public Collaborator an<Collaborator>()
    {
          try
          {
              var factory = factories.get_factory_that_can_create(typeof(Collaborator));
              return (Collaborator)factory.create();
          }
          catch (Exception e)
          {
              var exception = exception_creation_behaviour(typeof (Collaborator), e);
              throw exception;
          }
    }
  }
}