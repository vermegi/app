using System;

namespace app.utility.container
{
  public delegate Exception DependencyCreationExceptionFactory_Behaviour(Type type_that_could_not_be_created,Exception originating);
}