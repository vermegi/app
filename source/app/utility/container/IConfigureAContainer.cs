namespace app.utility.container
{
    public interface IConfigureAContainer
    {
        T GetDependencyFor<T>();
    }
}