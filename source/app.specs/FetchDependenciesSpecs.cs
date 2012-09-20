using Machine.Specifications;
using app.utility.container;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace prep.codekata.test
{
    [Subject(typeof(FetchDependencies))]
    public class FetchDependenciesSpecs
    {
        public abstract class FetchDependenciesConcern : Observes<IFetchDependencies, FetchDependencies>
        {

        }

        public class when_resolving_a_dependency : FetchDependenciesConcern
        {
            Establish c = () =>
            {
                configuration = depends.on<IConfigureAContainer>();
                implementer = new Implementer();
                configuration.setup(x => x.GetDependencyFor<IAmAContract>()).Return(implementer);
            };

            Because b = () =>
                        sut.an<IAmAContract>();

            It should_return_the_implementing_class = () =>
                                                      result.ShouldEqual(implementer);

            static object result;
            static IConfigureAContainer configuration;
            static Implementer implementer;
        }

        internal class Implementer : IAmAContract
        {
        }

        internal interface IAmAContract
        {
        }
    }

    internal interface IConfigureAContainer
    {
        T GetDependencyFor<T>();
    }
}