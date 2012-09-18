using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using app.web;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(CommandRegistry))]
  public class CommandRegistrySpecs
  {
    public abstract class concern : Observes<IFindCommands,
                                      CommandRegistry>
    {
    }

    public class when_finding_a_command_For_a_request : concern
    {
      public class and_it_has_the_command
      {
        Establish c = () =>
        {
          all_possible_commands = Enumerable.Range(1,1000).Select(x => fake.an<IProcessOneRequest>()).ToList();
          request = fake.an<IEncapsulateRequestDetails>();
          the_command_that_can_process = fake.an<IProcessOneRequest>();

          all_possible_commands.Add(the_command_that_can_process);
          depends.on<IEnumerable<IProcessOneRequest>>(all_possible_commands);

          the_command_that_can_process.setup(x => x.can_run(request)).Return(true);
        };

        Because b = () =>
          result = sut.get_the_command_that_can_process(request);

        It should_return_the_command_that_can_process_It = () =>
          result.ShouldEqual(the_command_that_can_process);

        static IProcessOneRequest result;
        static IProcessOneRequest the_command_that_can_process;
        static IEncapsulateRequestDetails request;
        static List<IProcessOneRequest> all_possible_commands;
      }

      public class and_it_does_not_have_the_COmmand
      {
        Establish c = () =>
        {
          all_possible_commands = Enumerable.Range(1,1000).Select(x => fake.an<IProcessOneRequest>()).ToList();
          request = fake.an<IEncapsulateRequestDetails>();
          the_special_case = fake.an<IProcessOneRequest>();
          depends.on<IEnumerable<IProcessOneRequest>>(all_possible_commands);
          depends.on<MissingCommandCreation_Behaviour>(() => the_special_case);
        };


        Because b = () =>
          result = sut.get_the_command_that_can_process(request);

        It should_return_the_special_case = () =>
          result.ShouldEqual(the_special_case);

        static IProcessOneRequest result;
        static IProcessOneRequest the_special_case;
        static IEncapsulateRequestDetails request;
        static List<IProcessOneRequest> all_possible_commands;
      }
    }
  }
}
