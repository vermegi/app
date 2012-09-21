using Machine.Specifications;
using app.tasks.startup;
using app.utility.container;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof(Start))]
    public class OrchestratorSpecs
    {
        public abstract class concern : Observes
        {

        }

        public class when_starting_with_a_certain_step : concern
        {
            Establish c = () =>
            {
                the_first_step = fake.an<ITakePartInStartup>();
            };

            Because b = () =>
                        result = Start.by<AComponent>();

            It should_give_me_a_stepcomposer_with_one_step = () =>
                                                             result.Steps.ShouldContainOnly(the_first_step);

            static IComposeSteps result;
            static ITakePartInStartup the_first_step;
        }

        public class AComponent : ITakePartInStartup
        {
            public void run()
            {
                throw new System.NotImplementedException();
            }
        }
    }
}