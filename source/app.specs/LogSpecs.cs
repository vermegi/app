using System;
using Machine.Specifications;
using app.utility.container;
using app.utility.logging;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(Log))]
  public class LogSpecs
  {
    public abstract class LogConcern : Observes
    {
    }

    public class when_providing_access_to_the_logging_mechanism : LogConcern
    {
      Establish c = () =>
      {
        log_extension_point_factory = fake.an<ICreateLoggers>();
        a_logger_bound_to_The_calling_type = fake.an<IProvideAccessToLoggingServices>();
        the_calling_type = typeof(when_providing_access_to_the_logging_mechanism);
        container_facade = fake.an<IFetchDependencies>();

        GetTheCallingType_Behaviour calling_type_resolution = () => the_calling_type;
        LoggingFactoryResolution_Behaviour log_factory_resolution = () => log_extension_point_factory;
        GetTheActiveContainer_Behaviour container_resolution = () => container_facade;

        log_extension_point_factory.setup(x => x.create_log_extension_bound_to(the_calling_type)).Return(a_logger_bound_to_The_calling_type);
        container_facade.setup(x => x.an<GetTheCallingType_Behaviour>()).Return(calling_type_resolution);
        container_facade.setup(x => x.an<LoggingFactoryResolution_Behaviour>()).Return(log_factory_resolution);

        spec.change(() => Dependencies.container_resolver).to(container_resolution);
      };

      Because b = () =>
        result = Log.the;

      It should_return_a_logger_bound_to_the_Type_thatR_equest_logging = () =>
        result.ShouldEqual(a_logger_bound_to_The_calling_type);



      static IProvideAccessToLoggingServices a_logger_bound_to_The_calling_type;
      static IProvideAccessToLoggingServices result;
      static ICreateLoggers log_extension_point_factory;
      static Type the_calling_type;
      static IFetchDependencies container_facade;
    }
  }
}