using System;
using System.Data;
using System.Data.SqlClient;
using Machine.Specifications;
using app.utility.container;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(FunctionalItemFactory))]
  public class FunctionalItemFactorySpecs
  {
    public abstract class concern : Observes<ICreateAnItem,
                                      FunctionalItemFactory>
    {
    }

    public class when_creating_an_item : concern
    {
      Establish c = () =>
      {
        the_connection = new SqlConnection();
        depends.on<Func<object>>(() => the_connection);
      };

      Because b = () =>
        result = sut.create();

      It should_create_the_item_using_the_method_it_was_provided = () =>
        result.ShouldEqual(the_connection);

      static object result;
      static IDbConnection the_connection;
    }
  }
}