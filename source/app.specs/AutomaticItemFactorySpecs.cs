using System.Data;
using System.Reflection;
using Machine.Specifications;
using app.specs.utility;
using app.utility.container;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(AutomaticItemFactory))]
  public class AutomaticItemFactorySpecs
  {
    public abstract class concern : Observes<ICreateAnItem,
                                      AutomaticItemFactory>
    {
    }

    public class when_creating_an_item : concern
    {
      Establish c = () =>
      {
        ctor_selection_strategy = depends.on<IPickTheCtorOnTheTypeToCreate>();
        container = depends.on<IFetchDependencies>();
        depends.on(typeof(ItemWithDependencies));

        the_connection = fake.an<IDbConnection>();
        the_command = fake.an<IDbCommand>();
        the_other = new SomeOtherItem();
        greediest =
          ObjectFactory.expressions.targeting<ItemWithDependencies>().ctor_pointed_at_by(
            () => new ItemWithDependencies(null, null, null));

        container.setup(x => x.an(typeof(IDbConnection))).Return(the_connection);
        container.setup(x => x.an(typeof(IDbCommand))).Return(the_command);
        container.setup(x => x.an(typeof(SomeOtherItem))).Return(the_other);

        ctor_selection_strategy.setup(x => x.pick_ctor_from(typeof(ItemWithDependencies))).Return(greediest);
      };

      Because b = () =>
        result = sut.create();

      It should_return_the_item_with_all_of_its_dependencies_met = () =>
      {
        var item = result.ShouldBeAn<ItemWithDependencies>();
        item.connection.ShouldEqual(the_connection);
        item.command.ShouldEqual(the_command);
        item.other_item.ShouldEqual(the_other);
      };

      static object result;
      static IDbConnection the_connection;
      static IDbCommand the_command;
      static SomeOtherItem the_other;
      static IFetchDependencies container;
      static IPickTheCtorOnTheTypeToCreate ctor_selection_strategy;
      static ConstructorInfo greediest;
    }

    public class ItemWithDependencies
    {
      public ItemWithDependencies(IDbConnection connection, IDbCommand command, SomeOtherItem other_item)
      {
        this.connection = connection;
        this.command = command;
        this.other_item = other_item;
      }

      public ItemWithDependencies(IDbConnection connection, IDbCommand command)
      {
        this.connection = connection;
        this.command = command;
      }

      public IDbConnection connection { get; private set; }
      public IDbCommand command { get; private set; }
      public SomeOtherItem other_item { get; private set; }
    }

    public class SomeOtherItem
    {
    }
  }
}