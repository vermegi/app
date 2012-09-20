using app.utility.container;

namespace app.utility.logging
{
  public class Log
  {
    public static IProvideAccessToLoggingServices the
    {
      get
      {
        var calling_type_resolution = Dependencies.fetch.an<GetTheCallingType_Behaviour>();
        var logging_factory_resolution = Dependencies.fetch.an<LoggingFactoryResolution_Behaviour>();
        return logging_factory_resolution ().create_log_extension_bound_to(calling_type_resolution());
      }
    }
  }
}