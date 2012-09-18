using System;
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
      It should_return_the_sum = () =>
        sut.add(2, 3).ShouldEqual(5);
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