using System;

namespace app.utility.logging
{
  public class Log
  {
    public static GetTheCallingType_Behaviour calling_type_resolver = () =>
    {
      throw new NotImplementedException("This needs to be set by a startup pipeline");
    };

    public static LoggingFactoryResolution_Behaviour log_factory_resolver = () =>
    {
      throw new NotImplementedException("This needs to be set by a startup pipeline");
    };

    public static IProvideAccessToLoggingServices the
    {
      get
      {
        return log_factory_resolver().create_log_extension_bound_to(calling_type_resolver());
      }
    }
  }
}