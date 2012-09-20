namespace app.utility.container
{
  public class Container : IFetchDependencies
  {
    IFindFactoriesForDependencies factories;

    public Container(IFindFactoriesForDependencies factories)
    {
      this.factories = factories;
    }

    public Collaborator an<Collaborator>()
    {
      var factory = factories.get_factory_that_can_create(typeof(Collaborator));
      return (Collaborator)factory.create();
    }
  }
}