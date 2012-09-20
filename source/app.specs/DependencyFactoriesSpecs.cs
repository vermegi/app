﻿using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using app.utility.container;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(DependencyFactories))]
  public class DependencyFactoriesSpecs
  {
    public abstract class concern : Observes<IFindFactoriesForDependencies,
                                      DependencyFactories>
    {
    }

    public class when_getting_the_factory_for_a_dependency : concern
    {
      public class and_it_has_the_dependency
      {
        Establish c = () =>
        {
          the_factory = fake.an<ICreateOneDependency>();
          all_factories = Enumerable.Range(1, 100).Select(x => fake.an<ICreateOneDependency>()).ToList();
          all_factories.Add(the_factory);

          the_factory.setup(x => x.can_create(typeof(int))).Return(true);
          depends.on<IEnumerable<ICreateOneDependency>>(all_factories);
        };

        Because b = () =>
          result = sut.get_factory_that_can_create(typeof(int));

        It should_return_the_factory_that_can_create_it = () =>
          result.ShouldEqual(the_factory);

        static ICreateOneDependency result;
        static ICreateOneDependency the_factory;
        static List<ICreateOneDependency> all_factories;
      }
    }
  }
}