using System;
using System.Data;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  public class CalculatorSpecs
  {
    public abstract class concern : Observes<Calculator>
    {
    }

    public class when_adding_two_numbers : concern
    {
      //arrange
      Establish c = () =>
      {
        connection = depends.on<IDbConnection>();   
      };


      It should_open_a_connection_To_the_db = () =>
        connection.received(x => x.Open());
        
      It should_return_the_sum = () =>
        sut.add(2, 3).ShouldEqual(5);

      static IDbConnection connection;
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