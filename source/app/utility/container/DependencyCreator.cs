using System;

namespace app.utility.container
{
    public class DependencyCreator : ICreateOneDependency
    {
        public object create()
        {
            throw new NotImplementedException();
        }

        public bool can_create(Type dependency)
        {
            throw new NotImplementedException();
        }
    }
}