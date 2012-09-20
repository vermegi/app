using System;
using Machine.Specifications;
using app.utility.container;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
    [Subject(typeof(DependencyCreator))]
    public class DependencyCreatorSpecs
    {
        public abstract class concern : Observes<ICreateOneDependency, DependencyCreator>
        {

        }

        public class when_it_has_a_behaviour_that_can_create_the_dependency : concern
        {
            Establish c = () =>
            {
                depends.on<Predicate<Type>>(x =>
                {
                    x.ShouldEqual(typeof(int));
                    return true;
                });
            };

            Because b = () => result = sut.can_create(typeof(int));

            It should_make_its_decision_by_using_its_type_specification = () =>
                                      result.ShouldBeTrue();

            static bool result;
        }

        public class when_creating_the_dependency : concern
        {
            Establish c = () =>
            {
              real_factory = depends.on<ICreateAnItem>();

              real_factory.setup(x => x.create()).Return(the_item);
            };

            Because b = () => result = sut.create();

            It should_delegate_to_the_actual_factory_for_creation = () =>
                                      result.ShouldEqual(the_item);

            static object result;
            static object the_item;
            static ICreateAnItem real_factory;
        }
    }
}
