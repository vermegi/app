using System;

namespace app.utility.container
{
    public class DependencyCreator : ICreateOneDependency
    {
        Predicate<Type> type_specification;
        ICreateAnItem real_factory;

        public DependencyCreator(Predicate<Type> type_specification,ICreateAnItem real_factory){
          this.type_specification = type_specification;
          this.real_factory = real_factory;
        }
        public object create()
        {
            return real_factory.create();
        }

        public bool can_create(Type dependency)
        {
            return type_specification(dependency);
        }
    }
}
