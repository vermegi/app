using System;

namespace app.utility.logging
{
  public interface ICreateLoggers
  {
    IProvideAccessToLoggingServices create_log_extension_bound_to(Type the_type_that_requested_logging);
  }
}