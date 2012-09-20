using Machine.Specifications;
using app.utility.container;
using developwithpassion.specifications.rhinomocks;

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
                depends.on<DependencyCreation_Behaviour>(x =>
                {
                    x.ShouldEqual(typeof(ContainerSpecs.IAmAContract));
                    return new ContainerSpecs.Implementer();                    
                });
            };

            Because b = () => sut.can_create(typeof(ContainerSpecs.IAmAContract));

            It should_say_Yes_I_Can = () =>
                                      result.ShouldEqual(true);

            static bool result;
        }
    }
}