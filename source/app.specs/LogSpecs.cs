using Machine.Specifications;
using app.utility.logging;
using developwithpassion.specifications.rhinomocks;

namespace prep.codekata.test
{
    [Subject(typeof (Log))]
    public class FileParserSpecs
    {
        public abstract class LogConcern : Observes<Log>
        {

        }

        public class when_providing_access_to_the_logging_mechanism : LogConcern
        {
            Because b = () =>
                        result = sut.the;

            It should_do_something = () =>
                                     result.ShouldBeOfType<ICanLog<when_providing_access_to_the_logging_mechanism>>();
            
            static ICanLog<object> result;                                    
        }
    }
}