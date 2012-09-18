using System;
using System.Data;
using System.Security.Principal;
using Machine.Specifications;
using Rhino.Mocks;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  public class CalculatorSpecs
  {
    public abstract class concern : Observes<Calculator>
    {
    }

    public class and_they_are_not_in_the_correct_security_group : concern
    {
      Because b = () =>
        sut.shut_off();

      Establish c = () =>
      {
        principal = fake.an<IPrincipal>();

        principal.setup(x => x.IsInRole(Arg<string>.Is.Anything)).Return(false);

//        spec.change(() => Thread.CurrentPrincipal).to(principal);
      };

      //      It should_throwA__Security_exception = () =>
      //        spec.exception_thrown.ShouldBeAn<SecurityException>();

      static IPrincipal principal;
    }

    public class when_adding_two_numbers : concern
    {
      //arrange
      Establish c = () =>
      {
        connection = depends.on<IDbConnection>();
        command = fake.an<IDbCommand>();

        connection.setup(x => x.CreateCommand()).Return(command);
      };

      Because b = () =>
        sut.add(1, 2);

      It should_open_a_connection_To_the_db = () =>
        connection.received(x => x.Open());

      It should_run_a_stored_procedure = () =>
        command.received(x => x.ExecuteNonQuery());

      It should_return_the_sum = () =>
        sut.add(2, 3).ShouldEqual(5);

      static IDbConnection connection;
      static IDbCommand command;
    }

    public class when_attempting_to_add_a_Negative_to_a_positive : concern
    {
      //act
      Because b = () =>
        spec.catch_exception(() => sut.add(2, -3));

      //assert
      It should_throw_an_argument_exception = () =>
        spec.exception_thrown.ShouldBeAn<ArgumentException>();
    }
  }
}